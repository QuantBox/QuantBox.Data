using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer
{
    [ProtoContract]
    public class DepthTick
    {
        [ProtoMember(1, DataFormat = DataFormat.ZigZag)]
        public int BidPrice1;
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int BidSize1;
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int AskPrice1;
        [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
        public int AskSize1;
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public int BidPrice2;
        [ProtoMember(6, DataFormat = DataFormat.ZigZag)]
        public int BidSize2;
        [ProtoMember(7, DataFormat = DataFormat.ZigZag)]
        public int AskPrice2;
        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int AskSize2;
        [ProtoMember(9, DataFormat = DataFormat.ZigZag)]
        public int BidPrice3;
        [ProtoMember(10, DataFormat = DataFormat.ZigZag)]
        public int BidSize3;
        [ProtoMember(11, DataFormat = DataFormat.ZigZag)]
        public int AskPrice3;
        [ProtoMember(12, DataFormat = DataFormat.ZigZag)]
        public int AskSize3;

        /// <summary>
        /// 指向下块多档行情
        /// </summary>
        [ProtoMember(13)]
        public DepthTick Next;

        [ProtoMember(14, DataFormat = DataFormat.ZigZag)]
        public int BidCount1;
        [ProtoMember(15, DataFormat = DataFormat.ZigZag)]
        public int AskCount1;

        [ProtoMember(16, DataFormat = DataFormat.ZigZag)]
        public int BidCount2;
        [ProtoMember(17, DataFormat = DataFormat.ZigZag)]
        public int AskCount2;
        [ProtoMember(18, DataFormat = DataFormat.ZigZag)]
        public int BidCount3;
        [ProtoMember(19, DataFormat = DataFormat.ZigZag)]
        public int AskCount3;
    }

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

    /// <summary>
    /// 配置信息，最关键的地方
    /// 如果为空表示差分数据，不为空表示快照数据
    /// </summary>
    [ProtoContract]
    public class ConfigInfo
    {
        /// <summary>
        /// 格式版本
        /// </summary>
        [ProtoMember(1)]
        public int Version;
        /// <summary>
        /// 实际值要先进行处理
        /// </summary>
        [ProtoMember(2)]
        public int TickSize;
        /// <summary>
        /// TickSize乘数，实际值*TickSizeMultiplier
        /// </summary>
        [ProtoMember(3)]
        public double TickSizeMultiplier;
        /// <summary>
        /// 结算价乘数，实际值*SettlementPriceMultiplier/TickSize
        /// </summary>
        [ProtoMember(4)]
        public int SettlementPriceMultiplier;
        /// <summary>
        /// 均价乘数，实际值*AveragePriceMultiplier/TickSize
        /// </summary>
        [ProtoMember(5)]
        public int AveragePriceMultiplier;
        /// <summary>
        /// 合约乘数
        /// </summary>
        [ProtoMember(6)]
        public double ContractMultiplier;
        /// <summary>
        /// ssf默认时间差，股指是500ms，Time_____ssf__会算出大量的5，默认减去此数还原成0
        /// </summary>
        [ProtoMember(7)]
        public int Time_ssf_Diff;

        public bool IsZero
        {
            get
            {
                return Version == 0
                    && TickSize == 0
                    && TickSizeMultiplier == 0
                    && SettlementPriceMultiplier == 0
                    && AveragePriceMultiplier == 0
                    && ContractMultiplier == 0
                    && Time_ssf_Diff == 0;
            }
        }

        public bool IsSame(ConfigInfo config)
        {
            return Version == config.Version
                && TickSize == config.TickSize
                && TickSizeMultiplier == config.TickSizeMultiplier
                && SettlementPriceMultiplier == config.SettlementPriceMultiplier
                && AveragePriceMultiplier == config.AveragePriceMultiplier
                && ContractMultiplier == config.ContractMultiplier
                && Time_ssf_Diff == config.Time_ssf_Diff;
        }

        public void SetTickSize(double val)
        {
            TickSize = (int)(TickSizeMultiplier * val);
        }

        public double GetTickSize()
        {
            return TickSize / TickSizeMultiplier;
        }

        public double TurnoverMultiplier
        {
            get {
                return TickSize * ContractMultiplier / TickSizeMultiplier;
            }
        }

        public ConfigInfo Default()
        {
            Version = 1;
            TickSize = 1;
            TickSizeMultiplier = 10000.0;
            SettlementPriceMultiplier = 100;
            AveragePriceMultiplier = 100;
            ContractMultiplier = 1;
            Time_ssf_Diff = 0;

            return this;
        }

        public ConfigInfo Flat()
        {
            Version = 0;
            TickSize = 1;
            TickSizeMultiplier = 1;
            SettlementPriceMultiplier = 1;
            AveragePriceMultiplier = 1;
            ContractMultiplier = 1;
            Time_ssf_Diff = 0;

            return this;
        }
    }

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
        public double AdjustingFactor
        {
            get
            {
                // 这地方可能有问题，先放着
                double fV = 1 + StockDividend + RightsOffering;
                double fP = RightsOfferingPrice * RightsOffering - CashDividend;
                double fS = (PreClose + fP) / fV;

                return PreClose/fS;
            }
        }

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

    [ProtoContract]
    public class PbTick
    {
        /// <summary>
        /// 配置信息，有就代表是快照，而不是差分
        /// </summary>
        [ProtoMember(1)]
        public ConfigInfo Config;
        /// <summary>
        /// 与上一笔的比
        /// </summary>
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int LastPrice;
        /// <summary>
        /// 成交量
        /// </summary>
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public long Volume;
        /// <summary>
        /// 持仓量
        /// </summary>
        [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
        public long OpenInterest;
        /// <summary>
        /// 成交额
        /// </summary>
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public long Turnover;
        /// <summary>
        /// 均价
        /// </summary>
        [ProtoMember(6, DataFormat = DataFormat.ZigZag)]
        public int AveragePrice;

        /// <summary>
        /// 交易日
        /// </summary>
        [ProtoMember(7, DataFormat = DataFormat.ZigZag)]
        public int TradingDay;      
        /// <summary>
        /// 实际日期
        /// </summary>
        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int ActionDay;
        [ProtoMember(9, DataFormat = DataFormat.ZigZag)]
        public int Time_HHmm;
        [ProtoMember(10, DataFormat = DataFormat.ZigZag)]
        public int Time_____ssf__;
        [ProtoMember(11, DataFormat = DataFormat.ZigZag)]
        public int Time________ff;

        /// <summary>
        /// N档数据
        /// </summary>
        [ProtoMember(12)]
        public DepthTick Depth1_3;
        /// <summary>
        /// Bar数据或高开低收
        /// </summary>
        [ProtoMember(13)]
        public BarInfo Bar;
        /// <summary>
        /// 涨跌停价格及结算价
        /// </summary>
        [ProtoMember(14)]
        public StaticInfo Static;
        /// <summary>
        /// 除权除息
        /// </summary>
        [ProtoMember(15)]
        public StockSplitInfo Split;

    }
}
