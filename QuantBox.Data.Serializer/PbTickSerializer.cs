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
        private V1.PbTickSerializer v1Reader = new V1.PbTickSerializer();
        private V2.PbTickSerializer v2Reader = new V2.PbTickSerializer();
        private V2.PbTickCodec v2Codec = new V2.PbTickCodec();
        private int nVersion = 2;
        private int nMaxVersion = 2;
        
        public V2.PbTick ReadOne(Stream stream)
        {
            // 计划如果简单的将V2和V1的文件合并成一个文件也能读取
            long Position = stream.Position;
            V2.PbTick tick = null;

            bool bFisrtException = true;

            do
            {
                try
                {
                    switch (nVersion)
                    {
                        case 1:
                            tick = V1_to_V2.Converter(v1Reader.ReadOne(stream));
                            break;
                        case 2:
                            tick = v2Reader.ReadOne(stream);
                            break;
                        default:
                            throw new Exception(string.Format("Invalid file, version {0}", nVersion));
                    }
                    return tick;
                }
                catch (ProtobufDataZeroException ex)
                {
                    bFisrtException = false;
                    nVersion = ex.CurrentVersion;
                    stream.Seek(Position, SeekOrigin.Begin);
                }
                catch(ProtoException ex)
                {
                    // 第一次出现问题后，从最新格式开始向后进行解析
                    if (bFisrtException)
                        nVersion = nMaxVersion;
                    else
                        --nVersion;

                    bFisrtException = false;
                    stream.Seek(Position, SeekOrigin.Begin);
                }
            }while(true);

            return tick;
        }

        public List<V2.PbTick> Read(Stream stream)
        {
            List<V2.PbTick> _list = new List<V2.PbTick>();

            while (true)
            {
                V2.PbTick tmp = ReadOne(stream);
                if (tmp == null)
                {
                    break;
                }

                _list.Add(tmp);
            }
            return _list;
        }

        public V2.PbTickView ReadOne2View(Stream stream)
        {
            return v2Codec.Data2View(ReadOne(stream), false);
        }

        public List<V2.PbTickView> Read2View(Stream stream)
        {
            return v2Codec.Data2View(Read(stream), false);
        }
    }
}
