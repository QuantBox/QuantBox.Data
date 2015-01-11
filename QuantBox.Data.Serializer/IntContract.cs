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
        /// 合约乘数
        /// </summary>
        [ProtoMember(4)]
        public int Multiplier;
        /// <summary>
        /// 合约名称
        /// </summary>
        [ProtoMember(5)]
        public string Symbol;
        /// <summary>
        /// 交易所
        /// </summary>
        [ProtoMember(6)]
        public string Exchange;
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
    }

    [ProtoContract]
    public class PbTick
    {
        /// <summary>
        /// 与上一笔的比
        /// </summary>
        [ProtoMember(1, DataFormat = DataFormat.ZigZag)]
        public int LastPrice;
        /// <summary>
        /// N档数据
        /// </summary>
        [ProtoMember(2)]
        public DepthTick Depth1_3;
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
        /// 成交额,实际值*1000
        /// </summary>
        [ProtoMember(5, DataFormat = DataFormat.ZigZag)]
        public long Turnover;
        /// <summary>
        /// 均价,实际值/10000
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
        /// Bar数据或高开低收
        /// </summary>
        [ProtoMember(12)]
        public BarInfo Bar;
        /// <summary>
        /// 涨跌停价格及结算价
        /// </summary>
        [ProtoMember(13)]
        public StaticInfo Static;
        /// <summary>
        /// 实际数*10000
        /// </summary>
        [ProtoMember(14)]
        public int TickSize;
        /// <summary>
        /// ssf默认时间差，股指是500ms，Time_____ssf__会算出大量的5，默认减去此数还原成0
        /// </summary>
        [ProtoMember(15)]
        public int Time_ssf_Diff;
    }
}
