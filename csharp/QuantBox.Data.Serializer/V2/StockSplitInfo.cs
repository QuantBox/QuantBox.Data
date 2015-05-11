using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    /// <summary>
    /// http://www2.resset.cn/product/db/datadict/cn/HKQTTNDIST.htm
    /// </summary>
    [ProtoContract]
    public class StockSplitInfo
    {
        /// <summary>
        /// 分红
        /// </summary>
        [ProtoMember(1)]
        public double CashDividend;
        /// <summary>
        /// 送股
        /// </summary>
        [ProtoMember(2)]
        public double StockDividend;
        /// <summary>
        /// 配股
        /// </summary>
        [ProtoMember(3)]
        public double RightsOffering;
        /// <summary>
        /// 配股价
        /// </summary>
        [ProtoMember(4)]
        public double RightsOfferingPrice;
        /// <summary>
        /// 
        /// 除权因子一定要有前一日收盘价的信息才能正确算出，
        /// </summary>
        [ProtoMember(5)]
        public double PreClose;
        /// <summary>
        /// 复权因子就是权息修复比例
        /// 计算向后复权价格：向后复权价格 = 原始价格 * 复权因子
        /// http://blog.sina.com.cn/s/blog_50dfbb0b0100b6ly.html
        /// 除权价＝（除权前一日收盘价＋配股价Ｘ配股比率－每股派息）／（１＋配股比率＋送股比率）
        /// 除权因子=收盘价/除权价
        ///	
        /// Price = m_fClose*fV - fP;
        /// </summary>
        
        //public double AdjustingFactor
        //{
        //    get
        //    {
        //        // 这地方可能有问题，先放着
        //        double fV = 1 + StockDividend + RightsOffering;
        //        double fP = RightsOfferingPrice * RightsOffering - CashDividend;
        //        double fS = (PreClose + fP) / fV;

        //        return PreClose/fS;
        //    }
        //}

        public bool IsZero
        {
            get
            {
                return CashDividend == 0
                       && StockDividend == 0
                       && RightsOffering == 0
                       && RightsOfferingPrice == 0
                       && PreClose == 0;
            }
        }
    }
}