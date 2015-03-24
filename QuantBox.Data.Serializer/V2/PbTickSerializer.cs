using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    public class PbTickSerializer
    {
        private PbTick _lastWrite = null;
        private PbTick _lastRead = null;

        public PbTickSerializer()
        {
            Codec = new PbTickCodec();
        }
        public PbTickCodec Codec { get; private set; }

        public void Reset()
        {
            _lastWrite = null;
            _lastRead = null;
        }

        public PbTick Write(PbTick data, Stream dest)
        {
            PbTick diff = Codec.Diff(_lastWrite, data);
            _lastWrite = data;

            diff.PrepareObjectBeforeWrite(Codec.Config);
            ProtoBuf.Serializer.SerializeWithLengthPrefix<PbTick>(dest, diff, PrefixStyle.Base128);

            return diff;
        }

        public void Write(IEnumerable<PbTick> list, Stream stream)
        {
            foreach (PbTick item in list)
            {
                Write(item, stream);
            }
        }

        public void Write(IEnumerable<PbTick> list, string output)
        {
            using (Stream stream = File.Open(output, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
            {
                Write(list, stream);
                stream.Close();
            }
        }

        public static void WriteCsv(IEnumerable<PbTick> list, string output)
        {
            if (list == null)
                return;

            PbTickCodec Codec = new PbTickCodec();

            // 将差分数据生成界面数据
            IEnumerable<PbTickView> _list = Codec.Data2View(Codec.Restore(list));

            // 保存
            using (TextWriter stream = new StreamWriter(output))
            {
                PbTickView t = new PbTickView();
                stream.WriteLine(t.ToCsvHeader());

                foreach (var l in _list)
                {
                    stream.WriteLine(l);
                }
                stream.Close();
            }
        }

        /// <summary>
        /// 可以同时得到原始的raw和解码后的数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="raw"></param>
        /// <returns></returns>
        public PbTick ReadOne(Stream source)
        {
            PbTick raw = ProtoBuf.Serializer.DeserializeWithLengthPrefix<PbTick>(source, PrefixStyle.Base128);
            if (raw == null)
                return null;
            raw.PrepareObjectAfterRead(Codec.Config);

            _lastRead = Codec.Restore(_lastRead, raw);
            if (_lastRead.Config.Version != 2)
            {
                throw new InvalidDataException("only support pd0 file version 2");
            }
            
            return _lastRead;
        }

        public List<PbTick> Read(Stream stream)
        {
            PbTick resotre = null;

            List<PbTick> _list = new List<PbTick>();

            while (true)
            {
                resotre = ReadOne(stream);
                if (resotre == null)
                {
                    break;
                }

                _list.Add(resotre);
            }
            stream.Close();

            return _list;
        }

        public List<PbTick> Read(string input)
        {
            using (Stream stream = File.Open(input, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return Read(stream);
            }
        }

    }
}
