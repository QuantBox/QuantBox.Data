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
        private bool bV2 = true;

        //public PbTickCodec Codec = new PbTickCodec();

        public V2.PbTick ReadOne(Stream stream)
        {
            long Position = stream.Position;
            V2.PbTick tick = null;

            try
            {
                if(bV2)
                {
                    tick = v2Reader.ReadOne(stream);
                }
                else
                {
                    V1.PbTick tmp = v1Reader.ReadOne(stream);
                    if (tmp == null)
                        return null;
                    tick = V1_to_V2.Converter(tmp);
                }
            }
            catch
            {
                bV2 = false;
                stream.Seek(Position, SeekOrigin.Begin);
                V1.PbTick tmp = v1Reader.ReadOne(stream);
                if (tmp == null)
                    return null;
                tick = V1_to_V2.Converter(tmp);
            }

            //Codec.Config = tick.Config;
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
    }
}
