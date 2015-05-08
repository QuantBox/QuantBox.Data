using ProtoBuf;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V2
{
    public class StaticInfoView
    {
        /// <summary>
        /// 与上一笔的LowerLimitPrice比较
        /// </summary>
        public double LowerLimitPrice { get; set; }
        /// <summary>
        /// 与上一笔的UpperLimitPrice比较
        /// </summary>
        public double UpperLimitPrice { get; set; }
        /// <summary>
        /// 实际数*100，因为IF交割日结算价两位小数
        /// </summary>
        public double SettlementPrice { get; set; }
        /// <summary>
        /// 合约名称
        /// </summary>
        public string Symbol { get; set; }
        /// <summary>
        /// 交易所
        /// </summary>
        public string Exchange { get; set; }
    }
}
