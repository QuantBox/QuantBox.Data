using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

            public string FullPath
            {
                get
                {
                    return Path.Combine(_Path, _Symbol + "_" + TradingDay + ".pd0");
                }
            }

            public void Close()
            {
                if(Stream != null)
                {
                    Stream.Close();
                    Stream = null;
                }
            }
        }

        public readonly Dictionary<string, WriterDataItem> Items = new Dictionary<string, WriterDataItem>();
        readonly string _path;

        public void WirteToFile(WriterDataItem item, bool flush = false)
        {
            if (item.Tick != null)
            {
                if (item.Stream == null)
                {
                    item.Stream = File.Open(item.FullPath, FileMode.Append, FileAccess.Write, FileShare.Read);
                    // 换天时，必须重置记录器，不然记录的数据是差分后数据，导致新文件无法解读
                    item.Serializer.Reset();
                }

                item.Serializer.Write(item.Tick, item.Stream);

                item.Tick = null;
                if (flush || (DateTime.Now - item.LastWriteTime).TotalSeconds >= 10)
                {
                    item.Stream.Flush(true);
                    item.LastWriteTime = DateTime.Now;
                }
            }
        }

        public TickWriter(string path)
        {
            _path = path;
        }

        public void Close()
        {
            foreach (var item in Items.Values)
            {
                WirteToFile(item, true);
                if (item.Stream != null)
                    item.Stream.Close();
            }
            Items.Clear();
        }

        public void AddInstrument(string symbol, double tickSize, double factor, int Time_ssf_Diff)
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

        public void RemoveInstrument(string symbol)
        {
            WriterDataItem item;
            if (Items.TryGetValue(symbol, out item))
            {
                if (item.Stream != null)
                {
                    item.Stream.Close();
                    item.Stream = null;
                }
                Items.Remove(symbol);
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
            WirteToFile(item);
        }

        public void Dispose()
        {
            Close();
        }
    }
}
