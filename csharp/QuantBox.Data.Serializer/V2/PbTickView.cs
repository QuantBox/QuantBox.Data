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

        public double LastPrice { get; set; }
        public double AskPrice1 { get; set; }

        public DepthItemView Ask1 { get; set; }
        public DepthItemView Bid1 { get; set; }
        public int AskPos { get; set; }
        public int BidPos { get; set; }
        public bool Descending { get; set; }

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

        public BarInfoView Bar { get; set; }
        public StaticInfoView Static { get; set; }
        public StockSplitInfoView Split { get; set; }

        public int LocalTime_Msec { get; set; }

        /// <summary>
        /// N档数据
        /// </summary>
        public List<DepthItemView> DepthList { get; set; }

        public static string ToCsvHeader()
        {
            return "BidPrice,BidSize,BidCount,AskPrice,AskSize,AskCount";
        }

        public override string ToString()
        {
            return LastPrice.ToString(CultureInfo.InvariantCulture);
        }

        public void LoadQuote(bool descending)
        {
            Descending = descending;
            if (descending) {
                AskPos = DepthListHelper.FindAsk1PositionDescending(DepthList, AskPrice1);
                BidPos = AskPos + 1;
                Ask1 = GetAsk(1);
                Bid1 = GetBid(1);
            }
            else {
                AskPos = DepthListHelper.FindAsk1Position(DepthList, AskPrice1);
                BidPos = AskPos - 1;
                Ask1 = GetAsk(1);
                Bid1 = GetBid(1);
            }
        }

        public DepthItemView GetBid(int level)
        {
            if (DepthList == null)
                return null;

            if (level > 0) {
                if (Descending) {
                    var pos = BidPos + (level - 1);
                    if (pos < DepthList.Count && pos >= 0) {
                        return DepthList[pos];
                    }
                }
                else {
                    var pos = BidPos - (level - 1);
                    if (pos >= 0 && pos < DepthList.Count) {
                        return DepthList[pos];
                    }
                }

            }
            return null;
        }
        public DepthItemView GetAsk(int level)
        {
            if (DepthList == null)
                return null;

            if (level > 0) {
                if (Descending) {
                    var pos = AskPos - (level - 1);
                    if (pos >= 0 && pos < DepthList.Count) {
                        return DepthList[pos];
                    }
                }
                else {
                    var pos = AskPos + (level - 1);
                    if (pos <= DepthList.Count - 1 && pos >= 0) {
                        return DepthList[pos];
                    }
                }
            }
            return null;
        }
    }
}