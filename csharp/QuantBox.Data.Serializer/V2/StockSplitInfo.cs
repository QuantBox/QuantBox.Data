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
        /// �ֺ�
        /// </summary>
        [ProtoMember(1)]
        public double CashDividend;
        /// <summary>
        /// �͹�
        /// </summary>
        [ProtoMember(2)]
        public double StockDividend;
        /// <summary>
        /// ���
        /// </summary>
        [ProtoMember(3)]
        public double RightsOffering;
        /// <summary>
        /// ��ɼ�
        /// </summary>
        [ProtoMember(4)]
        public double RightsOfferingPrice;
        /// <summary>
        /// 
        /// ��Ȩ����һ��Ҫ��ǰһ�����̼۵���Ϣ������ȷ�����
        /// </summary>
        [ProtoMember(5)]
        public double PreClose;
        /// <summary>
        /// ��Ȩ���Ӿ���ȨϢ�޸�����
        /// �������Ȩ�۸����Ȩ�۸� = ԭʼ�۸� * ��Ȩ����
        /// http://blog.sina.com.cn/s/blog_50dfbb0b0100b6ly.html
        /// ��Ȩ�ۣ�����Ȩǰһ�����̼ۣ���ɼۣ���ɱ��ʣ�ÿ����Ϣ������������ɱ��ʣ��͹ɱ��ʣ�
        /// ��Ȩ����=���̼�/��Ȩ��
        ///	
        /// Price = m_fClose*fV - fP;
        /// </summary>
        
        //public double AdjustingFactor
        //{
        //    get
        //    {
        //        // ��ط����������⣬�ȷ���
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