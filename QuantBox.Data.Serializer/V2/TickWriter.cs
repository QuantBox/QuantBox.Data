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
            }

            public FileStream Stream;
            public PbTickSerializer Serializer;
            public PbTick Tick;
            public DateTime LastWriteTime;

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
                if (Stream == null)
                    return;

                lock(locker)
                {
                    Stream.Close();
                    Stream = null;
                }
            }

            public void Write(bool flush)
            {
                if (Tick == null)
                    return;

                lock (locker)
                {
                    if (Stream == null)
                    {
                        Stream = File.Open(FullPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                        // 换天时，必须重置记录器，不然记录的数据是差分后数据，导致新文件无法解读
                        Serializer.Reset();
                    }

                    Serializer.Write(Tick, Stream);
                    Tick = null;

                    // 这种写法对于一天只有一笔的行情会不保存
                    Flush(flush);
                }
            }

            public void Flush(bool flush)
            {
                if (Stream == null)
                    return;

                lock (locker)
                {
                    if (flush || (DateTime.Now - LastWriteTime).TotalSeconds >= 10)
                    {
                        Stream.Flush(true);
                        LastWriteTime = DateTime.Now;
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
            _Timer.Interval = 1000*15;
            _Timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            Flush(false);
        }

        public void Close()
        {
            lock (locker)
            {
                foreach (var item in Items.Values)
                {
                    item.Write(true);
                    item.Close();
                }
                Items.Clear();
            }
        }

        public void Flush(bool flush)
        {
            lock (locker)
            {
                foreach (var item in Items.Values)
                {
                    item.Flush(flush);
                }
            }
        }

        public void AddInstrument(string symbol, double tickSize, double factor, int Time_ssf_Diff)
        {
            lock (locker)
            {
                if (!Items.ContainsKey(symbol))
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
            item.Write(false);
        }

        public void Dispose()
        {
            _Timer.Elapsed -= this.OnTimerElapsed;
            _Timer.Stop();
            Close();
        }
    }
}
