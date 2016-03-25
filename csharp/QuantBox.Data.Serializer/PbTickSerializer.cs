using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;
using QuantBox.Data.Serializer.V2;
using QuantBox.Data.Serializer.Converter;

namespace QuantBox.Data.Serializer
{
    public class PbTickSerializer
    {
        private readonly V1.PbTickSerializer _v1Reader = new V1.PbTickSerializer();
        private readonly V2.PbTickSerializer _v2Reader = new V2.PbTickSerializer();
        private readonly V2.PbTickCodec _v2Codec = new V2.PbTickCodec();
        private int _version = 2;
        private const int MaxVersion = 2;

        public V2.PbTick ReadOne(Stream stream)
        {
            // 计划如果简单的将V2和V1的文件合并成一个文件也能读取
            var position = stream.Position;
            var bFisrtException = true;
            do {
                try {
                    V2.PbTick tick;
                    switch (_version) {
                        case 1:
                            tick = V1_to_V2.Converter(_v1Reader.ReadOne(stream));
                            break;
                        case 2:
                            tick = _v2Reader.ReadOne(stream);
                            break;
                        default:
                            throw new Exception(string.Format("Invalid file, version {0}", _version));
                    }
                    return tick;
                }
                catch (ProtobufDataZeroException ex) {
                    bFisrtException = false;
                    _version = ex.CurrentVersion;
                    stream.Seek(position, SeekOrigin.Begin);
                }
                catch (ProtoException) {
                    // 第一次出现问题后，从最新格式开始向后进行解析
                    if (bFisrtException)
                        _version = MaxVersion;
                    else
                        _version -= 1;

                    bFisrtException = false;
                    stream.Seek(position, SeekOrigin.Begin);
                }
            } while (true);
        }

        public IEnumerable<V2.PbTick> Read(Stream stream)
        {
            while (true) {
                var tick = ReadOne(stream);
                if (tick == null) {
                    break;
                }
                yield return tick;
            }
        }

        public V2.PbTickView ReadOne2View(Stream stream)
        {
            return _v2Codec.Data2View(ReadOne(stream), false);
        }

        public List<V2.PbTickView> Read2View(Stream stream)
        {
            return _v2Codec.Data2View(Read(stream), false);
        }
    }
}
