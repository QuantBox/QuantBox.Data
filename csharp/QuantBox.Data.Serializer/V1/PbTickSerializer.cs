using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProtoBuf;

namespace QuantBox.Data.Serializer.V1
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

        /// <summary>
        /// 支持同时写向多个Stream
        /// 这样，只要有Tick来了，可以将转码后的小数据同时放在FileStream和MemoryStream.
        /// MemoryStream可以用来网络传输
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dest"></param>
        public PbTick Write(PbTick data, params Stream[] dest)
        {
            var diff = Codec.Diff(_lastWrite, data);
            _lastWrite = data;
            foreach (var d in dest)
            {
                ProtoBuf.Serializer.SerializeWithLengthPrefix<PbTick>(d, diff, PrefixStyle.Base128);
            }
            return diff;
        }

        /// <summary>
        /// 可以同时得到原始的raw和解码后的数据
        /// </summary>
        /// <param name="source"></param>
        /// <param name="raw"></param>
        /// <returns></returns>
        public PbTick ReadOne(Stream source)
        {
            var raw = ProtoBuf.Serializer.DeserializeWithLengthPrefix<PbTick>(source, PrefixStyle.Base128);
            if (raw == null)
                return null;
            _lastRead = Codec.Restore(_lastRead, raw);
            if (_lastRead.Config.Version != 1)
            {
                throw new ProtobufDataZeroException("only support pd0 file version 1", _lastRead.Config.Version, 1);
            }
            return _lastRead;
        }

        public static void WriteOne(PbTick tick, Stream stream)
        {
            ProtoBuf.Serializer.SerializeWithLengthPrefix<PbTick>(stream, tick, PrefixStyle.Base128);
        }

        public static void Write(IEnumerable<PbTick> list, Stream stream)
        {
            if (list == null)
                return;

            foreach (var item in list)
            {
                PbTickSerializer.WriteOne(item, stream);
            }
        }

        public static void Write(IEnumerable<PbTick> list, string output)
        {
            //using (Stream stream = File.OpenWrite(output))
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

            var Codec = new PbTickCodec();

            // 将差分数据生成界面数据
            IEnumerable<PbTickView> _list = Codec.Data2View(Codec.Restore(list), false);

            // 保存
            using (TextWriter stream = new StreamWriter(output))
            {
                var t = new PbTickView();
                stream.WriteLine(t.ToCsvHeader());

                foreach (var l in _list)
                {
                    stream.WriteLine(l);
                }
                stream.Close();
            }
        }
    }
}
