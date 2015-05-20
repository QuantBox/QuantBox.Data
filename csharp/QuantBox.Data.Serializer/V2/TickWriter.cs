using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace QuantBox.Data.Serializer.V2
{
    public class TickWriter : IDisposable
    {
        public class WriterDataItem
        {
            public WriterDataItem(FileStream stream, PbTickSerializer serializer, string path,string symbol)
            {
                Stream = stream;
                Serializer = serializer;
                _Symbol = symbol;
                _Path = path;
                LastWriteTime = DateTime.Now;
            }

            public FileStream Stream;
            public PbTickSerializer Serializer;
            public PbTick Tick;
            public DateTime LastWriteTime;
            //public bool HasData;

            public int TradingDay;
            public string _Symbol;
            public string _Path;

            private object locker = new object();

            public string FullPath
            {
                get
                {
                    return Path.Combine(_Path, _Symbol + "_" + TradingDay + ".pd0");
                }
            }

            public void Close()
            {
                lock(locker)
                {
                    if (Stream == null)
                        return;

                    Stream.Close();
                    Stream = null;
                }
            }

            public void Write()
            {
                lock (locker)
                {
                    if (Tick == null)
                        return;

                    if (Stream == null)
                    {
                        Stream = File.Open(FullPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                        // 换天时，必须重置记录器，不然记录的数据是差分后数据，导致新文件无法解读
                        Serializer.Reset();
                    }

                    Serializer.Write(Tick, Stream);
                    Tick = null;
                    //HasData = true;
                    
                    FlushInWriter();
                }
            }

            public void FlushInWriter()
            {
                lock (locker)
                {
                    if (Stream == null)
                        return;

                    double ts = (DateTime.Now - LastWriteTime).TotalSeconds;
                    // 与上次一写入相比大于10s就写入
                    // 但对于行情很少不变动的，会出现没有机会写入的情况，所以需要定时器来帮忙
                    if (ts >= 10)
                    {
                        //if(HasData)
                            Stream.Flush(true);
                        //HasData = false;
                        LastWriteTime = DateTime.Now;
                    }
                }
            }

            public void FlushInTimer()
            {
                lock (locker)
                {
                    if (Stream == null)
                        return;

                    double ts = (DateTime.Now - LastWriteTime).TotalSeconds;
                    // 每10秒写一次
                    if (ts >= 10)
                    {
                        //if (HasData)
                            Stream.Flush(true);
                        //HasData = false;

                        // 1分钟没有写入数据就关闭文件句柄
                        // 这样留下机会可以进行删除
                        if (ts > 1 * 60)
                        {
                            Close();
                        }
                    }
                }
            }
        }

        public readonly Dictionary<string, WriterDataItem> Items = new Dictionary<string, WriterDataItem>();
        readonly string _path;
        private object locker = new object();
        private Timer _Timer = new Timer();

        public TickWriter(string path)
        {
            _path = path;

            _Timer.Elapsed += this.OnTimerElapsed;
            // 每15秒遍历一次
            _Timer.Interval = 1000*15;
            _Timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            FlushInTimer();
        }

        public void Close()
        {
            lock (locker)
            {
                foreach (var item in Items.Values)
                {
                    item.Write();
                    item.Close();
                }
                Items.Clear();
            }
        }

        public void FlushInTimer()
        {
            lock (locker)
            {
                foreach (var item in Items.Values)
                {
                    item.FlushInTimer();
                }
            }
        }

        public void AddInstrument(string symbol, double tickSize, double factor, int Time_ssf_Diff)
        {
            lock (locker)
            {
                WriterDataItem item;
                if (!Items.TryGetValue(symbol, out item))
                {
                    var serializer = new PbTickSerializer();
                    if (tickSize > 0)
                    {
                        serializer.Codec.Config.SetTickSize(tickSize);
                        serializer.Codec.TickSize = serializer.Codec.Config.GetTickSize();
                    }
                    if (factor > 0)
                        serializer.Codec.Config.ContractMultiplier = factor;
                    serializer.Codec.Config.Time_ssf_Diff = Time_ssf_Diff;

                    Items.Add(symbol, new WriterDataItem(null, serializer, _path, symbol));
                }
                else
                {
                    // 有可能要不关软件，连续工作，但tickSize又发生了变化
                    var serializer = item.Serializer;
                    if (serializer != null)
                    {
                        if (tickSize > 0)
                        {
                            serializer.Codec.Config.SetTickSize(tickSize);
                            serializer.Codec.TickSize = serializer.Codec.Config.GetTickSize();
                        }
                        if (factor > 0)
                            serializer.Codec.Config.ContractMultiplier = factor;
                        serializer.Codec.Config.Time_ssf_Diff = Time_ssf_Diff;
                    }
                }
            }
        }

        public void RemoveInstrument(string symbol)
        {
            lock (locker)
            {
                WriterDataItem item;
                if (Items.TryGetValue(symbol, out item))
                {
                    item.Close();
                    Items.Remove(symbol);
                }
            }
        }

        public bool Write(PbTick tick)
        {
            WriterDataItem item;
            if (Items.TryGetValue(tick.Static.Symbol, out item))
            {
                Write(item, tick);
                return true;
            }
            return false;
        }

        public void Write(WriterDataItem item,PbTick tick)
        {
            // 对于换交易日，应当将前一天的关闭
            if (item.TradingDay != tick.TradingDay)
            {
                item.Close();
                item.TradingDay = tick.TradingDay;
            }
            item.Tick = tick;
            item.Write();
        }

        public void Dispose()
        {
            _Timer.Elapsed -= this.OnTimerElapsed;
            _Timer.Stop();
            Close();
        }
    }
}
