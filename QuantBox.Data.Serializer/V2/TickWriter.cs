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
            public WriterDataItem(FileStream stream, PbTickSerializer serializer, string path)
            {
                Stream = stream;
                Serializer = serializer;
                Path = path;
            }

            public FileStream Stream;
            public PbTickSerializer Serializer;
            public PbTick Tick;
            public DateTime LastWriteTime;
            public string Path;
        }

        protected readonly Dictionary<string, WriterDataItem> Items = new Dictionary<string, WriterDataItem>();
        readonly string _path;
        readonly int _tradingDay;

        public void WirteToFile(WriterDataItem item, bool flush = false)
        {
            if (item.Tick != null)
            {
                if (item.Stream == null)
                {
                    item.Stream = File.Open(item.Path, FileMode.Append, FileAccess.Write, FileShare.Read);
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

        public TickWriter(string path, int tradingDay)
        {
            _path = path;
            _tradingDay = tradingDay;
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
                var file = Path.Combine(_path, symbol + "_" + _tradingDay + ".pd0");
                var serializer = new PbTickSerializer();
                if (tickSize > 0)
                {
                    serializer.Codec.Config.SetTickSize(tickSize);
                    serializer.Codec.TickSize = serializer.Codec.Config.GetTickSize();
                }
                if (factor > 0)
                    serializer.Codec.Config.ContractMultiplier = factor;
                serializer.Codec.Config.Time_ssf_Diff = Time_ssf_Diff;

                Items.Add(symbol, new WriterDataItem(null, serializer, file));
            }
        }

        public bool Write(PbTick tick)
        {
            WriterDataItem item;
            if (Items.TryGetValue(tick.Static.Symbol, out item))
            {
                item.Tick = tick;
                WirteToFile(item);
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
