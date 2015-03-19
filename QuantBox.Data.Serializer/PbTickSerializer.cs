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

        public List<V2.PbTick> Read(Stream stream)
        {
            try
            {
                return v2Reader.Read(stream);
            }
            catch
            {
                stream.Position = 0;
                V1.PbTick raw = null;
                V1.PbTick tmp = null;

                List<V2.PbTick> _list = new List<V2.PbTick>();

                while (true)
                {
                    tmp = v1Reader.Read(stream,out raw);
                    if (tmp == null)
                    {
                        break;
                    }

                    _list.Add(V1_to_V2.Converter(tmp));
                }
                return _list;
            }
        }
    }
}
