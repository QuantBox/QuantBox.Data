using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    [ProtoContract]
    public class StaticInfo
    {
        /// <summary>
        /// 与上一笔的LowerLimitPrice比较
        /// </summary>
        [ProtoMember(1, DataFormat = DataFormat.ZigZag)]
        public int LowerLimitPrice;
        /// <summary>
        /// 与上一笔的UpperLimitPrice比较
        /// </summary>
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int UpperLimitPrice;
        /// <summary>
        /// 实际数*100，因为IF交割日结算价两位小数
        /// </summary>
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int SettlementPrice;
        /// <summary>
        /// 合约名称
        /// </summary>
        [ProtoMember(4)]
        public string Symbol;
        /// <summary>
        /// 交易所
        /// </summary>
        [ProtoMember(5)]
        public string Exchange;
        public bool IsZero
        {
            get
            {
                return LowerLimitPrice == 0
                       && UpperLimitPrice == 0
                       && SettlementPrice == 0
                       && string.IsNullOrWhiteSpace(Symbol)
                       && string.IsNullOrWhiteSpace(Exchange);
            }
        }
    }
}