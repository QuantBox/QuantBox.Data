using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <summary>
        /// 市场深度，比如说只有一档行情时，由于价格变动时用10,-10一类的表示太占，所这个来截断成10,0
        /// </summary>
        [ProtoMember(8)]
        public int MarketDepth;
        [ProtoMember(9)]
        public int MarketType;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(10)]
        public int Volume_Total_Or_Increment;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(11)]
        public int Turnover_Total_Or_Increment;


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
                    && Time_ssf_Diff == 0
                    && MarketDepth == 0
                    && MarketType == 0
                    && Volume_Total_Or_Increment == 0
                    && Turnover_Total_Or_Increment == 0;
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
                && Time_ssf_Diff == config.Time_ssf_Diff
                && MarketDepth == config.MarketDepth
                && MarketType == config.MarketType
                && Volume_Total_Or_Increment == config.Volume_Total_Or_Increment
                && Turnover_Total_Or_Increment == config.Turnover_Total_Or_Increment;
            ;
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
            Version = 2;
            TickSize = 1;
            TickSizeMultiplier = 10000.0;
            SettlementPriceMultiplier = 100;
            AveragePriceMultiplier = 100;
            ContractMultiplier = 1;
            Time_ssf_Diff = 0;
            MarketDepth = 0;
            MarketType = 2;
            Volume_Total_Or_Increment = 0;
            Turnover_Total_Or_Increment = 0;

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

    [ProtoContract]
    public class PbTick
    {
        /// <summary>
        /// 配置信息，有就代表是快照，而不是差分
        /// </summary>
        [ProtoMember(1)]
        public ConfigInfo Config;

        #region 时间部分
        [ProtoMember(2, DataFormat = DataFormat.ZigZag)]
        public int TradingDay;
        [ProtoMember(3, DataFormat = DataFormat.ZigZag)]
        public int ActionDay;
        [ProtoMember(4, DataFormat = DataFormat.ZigZag)]
        public int Time_HHmm;
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public int Time_____ssf__;
        [ProtoMember(6, DataFormat = DataFormat.ZigZag)]
        public int Time________ff;
        #endregion

        #region 价格部分
        [ProtoMember(7, DataFormat = DataFormat.ZigZag)]
        public int LastPrice;
        /// <summary>
        /// 指向卖一价，如果不存在卖一价就......
        /// </summary>
        [ProtoMember(8, DataFormat = DataFormat.ZigZag)]
        public int AskPrice1;
        /// <summary>
        /// N档数据
        /// </summary>
        [ProtoMember(9)]
        public DepthTick Depth;
        #endregion

        #region 量部分
        /// <summary>
        /// 成交量
        /// </summary>
        [ProtoMember(10, DataFormat = DataFormat.ZigZag)]
        public long Volume;
        /// <summary>
        /// 持仓量
        /// </summary>
        [ProtoMember(11, DataFormat = DataFormat.ZigZag)]
        public long OpenInterest;
        /// <summary>
        /// 成交额
        /// </summary>
        [ProtoMember(12, DataFormat = DataFormat.ZigZag)]
        public long Turnover;
        /// <summary>
        /// 均价
        /// </summary>
        [ProtoMember(13, DataFormat = DataFormat.ZigZag)]
        public int AveragePrice;
        #endregion

        /// <summary>
        /// Bar数据或高开低收
        /// </summary>
        [ProtoMember(14)]
        public BarInfo Bar;
        /// <summary>
        /// 涨跌停价格及结算价
        /// </summary>
        [ProtoMember(15)]
        public StaticInfo Static;
        /// <summary>
        /// 除权除息
        /// </summary>
        [ProtoMember(16)]
        public StockSplitInfo Split;
        /// <summary>
        /// 在ActionDay+Time的基础上加N毫秒
        /// </summary>
        [ProtoMember(17, DataFormat = DataFormat.ZigZag)]
        public int LocalTime_Msec;

        /// <summary>
        /// 内部使用，保存到硬盘时使用Depth
        /// </summary>
        public List<DepthItem> DepthList;
        
        /// <summary>
        /// 将列表中的数据平铺到结构体中
        /// 只在保存到文件时操作,其它时候都不要调用
        /// 以后用户要使用数据时直接操作列表即可
        /// </summary>
        public void PrepareObjectBeforeWrite(ConfigInfo _Config)
        {
            if (DepthList == null || DepthList.Count == 0)
            {
                Depth = null;
                return;
            }

            List<DepthItem> tempList = new List<DepthItem>();

            DepthListHelper.PriceMinusInOneList(DepthList, tempList);
            

            // 还是使用新的，因为不知道以前是否已经有数据，导致混淆
            Depth = new DepthTick();
            //if(tempList.Count>0)
            //    tempList[0].Price = LastPrice - tempList[0].Price;
            DepthListHelper.ListToStruct(tempList, _Config.MarketType, Depth);
        }

        /// <summary>
        /// 将结构体的数据展开到列表中
        /// 读取出数据后立即使用展开,其它时候都不要调用
        /// 以后用户要使用数据时直接操作列表即可
        /// </summary>
        public void PrepareObjectAfterRead(ConfigInfo _Config)
        {
            if (Depth == null || Depth.IsZero)
            {
                DepthList = null;
                return;
            }

            List<DepthItem> tempList = new List<DepthItem>();

            DepthListHelper.StructToList(Depth, _Config.MarketType, tempList);
            // 不能这么写，因为还原时LastPrice还是一个很小的值
            //if (tempList.Count > 0)
            //    tempList[0].Price = LastPrice + tempList[0].Price;

            DepthList = new List<DepthItem>();
            DepthListHelper.PriceAddInOneList(tempList, DepthList);
        }
    }
}
