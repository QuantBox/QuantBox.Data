using System;
using System.Collections.Generic;
using System.Globalization;

namespace QuantBox.Data.Serializer.V2
{
    public class PbTickView
    {
        public ConfigInfoView Config { get; set; }

        public int TradingDay { get; set; }
        public int ActionDay { get; set; }
        public int Time_HHmm { get; set; }
        public int Time_____ssf__ { get; set; }
        public int Time________ff { get; set; }

        /// <summary>
        /// 与上一笔的比
        /// </summary>
        public double LastPrice { get; set; }
        public double AskPrice1 { get; set; }

        public DepthItemView Ask1 { get; set; }
        public DepthItemView Bid1 { get; set; }
        public int AskPos { get; set; }
        public int BidPos { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public long Volume { get; set; }
        /// <summary>
        /// 持仓量
        /// </summary>
        public long OpenInterest { get; set; }
        /// <summary>
        /// 成交额,实际值/10000
        /// </summary>
        public double Turnover { get; set; }
        /// <summary>
        /// 均价,实际值*100
        /// </summary>
        public double AveragePrice { get; set; }

        /// <summary>
        /// Bar数据或高开低收
        /// </summary>
        public BarInfoView Bar { get; set; }
        /// <summary>
        /// 涨跌停价格及结算价
        /// </summary>
        public StaticInfoView Static { get; set; }

        public StockSplitInfoView Split { get; set; }

        public int LocalTime_Msec { get; set; }

        /// <summary>
        /// N档数据
        /// </summary>
        public List<DepthItemView> DepthList { get; set; }

        public string ToCsvHeader()
        {
            return "BidPrice,BidSize,BidCount,AskPrice,AskSize,AskCount";
        }

        public override string ToString()
        {
            return LastPrice.ToString(CultureInfo.InvariantCulture);
        }

        public void LoadQuote()
        {
            AskPos = DepthListHelper.FindAsk1Position(DepthList, AskPrice1);
            BidPos = AskPos - 1;
            Ask1 = GetAsk(0);
            Bid1 = GetBid(0);
        }

        public DepthItemView GetBid(int level)
        {
            if (level > 0) {
                var pos = BidPos - (level - 1);
                if (pos >= 0) {
                    return DepthList[pos];
                }
            }
            return null;
        }
        public DepthItemView GetAsk(int level)
        {
            if (level > 0) {
                var pos = AskPos + (level - 1);
                if (pos <= DepthList.Count - 1) {
                    return DepthList[pos];
                }
            }
            return null;
        }
    }
}