using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V2
{
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
        /// 指向卖一价，如果不存在卖一价就指向买一价
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
        /// 方便数据读取，存储传输时使用 Depth
        /// </summary>
        public List<DepthItem> DepthList;
        
        /// <summary>
        /// 将列表中的数据平铺到结构体中
        /// 只在保存到文件时操作,其它时候都不要调用
        /// 以后用户要使用数据时直接操作列表即可
        /// </summary>
        public void PrepareObjectBeforeWrite(ConfigInfo config)
        {
            if (DepthList == null || DepthList.Count == 0)
            {
                Depth = null;
                return;
            }

            var tempList = new List<DepthItem>();

            DepthListHelper.PriceMinusInOneList(DepthList, tempList);
            

            // 还是使用新的，因为不知道以前是否已经有数据，导致混淆
            Depth = new DepthTick();
            //if(tempList.Count>0)
            //    tempList[0].Price = LastPrice - tempList[0].Price;
            DepthListHelper.ListToStruct(tempList, config.MarketType, Depth);
        }

        /// <summary>
        /// 将结构体的数据展开到列表中
        /// 读取出数据后立即使用展开,其它时候都不要调用
        /// 以后用户要使用数据时直接操作列表即可
        /// </summary>
        public void PrepareObjectAfterRead(ConfigInfo config)
        {
            if (Depth == null || Depth.IsZero)
            {
                DepthList = null;
                return;
            }

            var tempList = new List<DepthItem>();

            DepthListHelper.StructToList(Depth, config.MarketType, tempList);
            // 不能这么写，因为还原时LastPrice还是一个很小的值
            //if (tempList.Count > 0)
            //    tempList[0].Price = LastPrice + tempList[0].Price;

            DepthList = new List<DepthItem>();
            DepthListHelper.PriceAddInOneList(tempList, DepthList);
        }
    }
}
