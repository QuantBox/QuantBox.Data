using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    [ProtoContract]
    public class BarInfo
    {
        /// <summary>
        /// 与上一笔的Open比较
        /// </summary>
        [ProtoMember(1, DataFormat = DataFormat.ZigZag)]
        public int Open;
        /// <summary>
        /// 与上一笔的High比较
        /// </summary>
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int High;
        /// <summary>
        /// 与上一笔的Low比较
        /// </summary>
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int Low;
        /// <summary>
        /// 与上一笔的Close比较
        /// </summary>
        [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
        public int Close;
        /// <summary>
        /// 与上一笔的BarSize比较
        /// </summary>
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public int BarSize;

        public bool IsZero
        {
            get
            {
                return Open == 0
                       && High == 0
                       && Low == 0
                       && Close == 0
                       && BarSize == 0;
            }
        }
    }
}