using ProtoBuf;
using System;
using System.Collections.Generic;
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

    public class BarInfoView
    {
        /// <summary>
        /// 与上一笔的Open比较
        /// </summary>
        public double Open { get; set; }
        /// <summary>
        /// 与上一笔的High比较
        /// </summary>
        public double High { get; set; }
        /// <summary>
        /// 与上一笔的Low比较
        /// </summary>
        public double Low { get; set; }
        /// <summary>
        /// 与上一笔的Close比较
        /// </summary>
        public double Close { get; set; }
        /// <summary>
        /// 与上一笔的BarSize比较
        /// </summary>
        public int BarSize { get; set; }
    }

    public class ConfigInfoView
    {
        public int Version { get; set; }

        public int TickSize { get; set; }

        public double TickSizeMultiplier { get; set; }

        public int SettlementPriceMultiplier { get; set; }

        public int AveragePriceMultiplier { get; set; }

        public double ContractMultiplier { get; set; }

        public int Time_ssf_Diff { get; set; }
        public int MarketDepth { get; set; }
        public int MarketType { get; set; }
        public int Volume_Total_Or_Increment { get; set; }
        public int Turnover_Total_Or_Increment { get; set; }

    }

    public class StockSplitInfoView
    {
        public double CashDividend { get; set; }
        public double StockDividend { get; set; }
        public double RightsOffering { get; set; }
        public double RightsOfferingPrice { get; set; }

        public double PreClose { get; set; }
        public double AdjustingFactor { get; set; }
    }

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
            return LastPrice.ToString();
        }
    }

    public class DepthItemView
    {
        public double Price { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public string ToCsvHeader()
        {
            return "Price,Size,Count";
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",
                Price, Size, Count);
        }
    }
}
