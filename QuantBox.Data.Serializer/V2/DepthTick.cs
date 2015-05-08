using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    [ProtoContract]
    public class DepthTick
    {
        [ProtoMember(1, DataFormat = DataFormat.ZigZag)]
        public int Value1;
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int Value2;
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int Value3;
        [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
        public int Value4;
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public int Value5;
        [ProtoMember(6, DataFormat = DataFormat.ZigZag)]
        public int Value6;
        [ProtoMember(7, DataFormat = DataFormat.ZigZag)]
        public int Value7;
        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int Value8;
        [ProtoMember(9, DataFormat = DataFormat.ZigZag)]
        public int Value9;
        [ProtoMember(10, DataFormat = DataFormat.ZigZag)]
        public int Value10;
        [ProtoMember(11, DataFormat = DataFormat.ZigZag)]
        public int Value11;
        [ProtoMember(12, DataFormat = DataFormat.ZigZag)]
        public int Value12;
        [ProtoMember(13, DataFormat = DataFormat.ZigZag)]
        public int Value13;
        [ProtoMember(14, DataFormat = DataFormat.ZigZag)]
        public int Value14;
        /// <summary>
        /// 指向下块多档行情数据区
        /// </summary>
        [ProtoMember(15)]
        public DepthTick Next;

        public bool IsZero
        {
            get
            {
                return Value1 == 0
                       && Value2 == 0
                       && Value3 == 0
                       && Value4 == 0
                       && Value5 == 0
                       && Value6 == 0
                       && Value7 == 0
                       && Value8 == 0
                       && Value9 == 0
                       && Value10 == 0
                       && Value11 == 0
                       && Value12 == 0
                       && Value13 == 0
                       && Value14 == 0
                       && (Next == null || Next.IsZero);
            }
        }
    }
}