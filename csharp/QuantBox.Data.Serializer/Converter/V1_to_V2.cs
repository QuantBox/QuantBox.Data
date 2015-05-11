using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuantBox.Data.Serializer;

namespace QuantBox.Data.Serializer.Converter
{
    public class V1_to_V2
    {
        /// <summary>
        /// 只能对完整版数据进行转换
        /// </summary>
        /// <param name="oldTick"></param>
        /// <returns></returns>
        public static V2.PbTick Converter(V1.PbTick oldTick)
        {
            if (oldTick == null)
                return null;

            V2.PbTick tick = new V2.PbTick();

            tick.Config = new V2.ConfigInfo().Default();
            tick.Config.Version = oldTick.Config.Version;
            tick.Config.AveragePriceMultiplier = oldTick.Config.AveragePriceMultiplier;
            tick.Config.ContractMultiplier = oldTick.Config.ContractMultiplier;
            tick.Config.SettlementPriceMultiplier = oldTick.Config.SettlementPriceMultiplier;
            tick.Config.TickSize = oldTick.Config.TickSize;
            tick.Config.TickSizeMultiplier = oldTick.Config.TickSizeMultiplier;
            tick.Config.Time_ssf_Diff = oldTick.Config.Time_ssf_Diff;

            tick.DepthList = new List<V2.DepthItem>();
            V1.DepthTick next = oldTick.Depth1_3;
            if (next != null)
            {
                if (next.AskSize1 != 0)
                    tick.AskPrice1 = next.AskPrice1;
                else
                    tick.AskPrice1 = next.BidPrice1 + 1;
            }

            while (next != null)
            {
                if (next.AskSize1 != 0)
                    tick.DepthList.Add(new V2.DepthItem(next.AskPrice1, next.AskSize1, next.AskCount1));
                if (next.AskSize2 != 0)
                    tick.DepthList.Add(new V2.DepthItem(next.AskPrice2, next.AskSize2, next.AskCount2));
                if (next.AskSize3 != 0)
                    tick.DepthList.Add(new V2.DepthItem(next.AskPrice3, next.AskSize3, next.AskCount3));

                if (next.BidSize1 != 0)
                    tick.DepthList.Insert(0, new V2.DepthItem(next.BidPrice1, next.BidSize1, next.BidCount1));
                if (next.BidSize2 != 0) 
                    tick.DepthList.Insert(0, new V2.DepthItem(next.BidPrice2, next.BidSize2, next.BidCount2));
                if (next.BidSize3 != 0) 
                    tick.DepthList.Insert(0, new V2.DepthItem(next.BidPrice3, next.BidSize3, next.BidCount3));

                // 指向下一个
                next = next.Next;
            }

            if(oldTick.Bar != null)
            {
                tick.Bar = new V2.BarInfo();
                tick.Bar.BarSize = oldTick.Bar.BarSize;
                tick.Bar.Close = oldTick.Bar.Close;
                tick.Bar.High = oldTick.Bar.High;
                tick.Bar.Low = oldTick.Bar.Low;
                tick.Bar.Open = oldTick.Bar.Open;
            }

            if (oldTick.Split != null)
            {
                tick.Split = new V2.StockSplitInfo();
                tick.Split.CashDividend = oldTick.Split.CashDividend;
                tick.Split.PreClose = oldTick.Split.PreClose;
                tick.Split.RightsOffering = oldTick.Split.RightsOffering;
                tick.Split.RightsOfferingPrice = oldTick.Split.RightsOfferingPrice;
                tick.Split.StockDividend = oldTick.Split.StockDividend;
            }

            if(oldTick.Static != null)
            {
                tick.Static = new V2.StaticInfo();
                tick.Static.Exchange = oldTick.Static.Exchange;
                tick.Static.LowerLimitPrice = oldTick.Static.LowerLimitPrice;
                tick.Static.SettlementPrice = oldTick.Static.SettlementPrice;
                tick.Static.Symbol = oldTick.Static.Exchange;
                tick.Static.UpperLimitPrice = oldTick.Static.UpperLimitPrice;
            }

            tick.ActionDay = oldTick.ActionDay;
            tick.TradingDay = oldTick.TradingDay;
            tick.Time_HHmm = oldTick.Time_HHmm;
            tick.Time_____ssf__ = oldTick.Time_____ssf__;
            tick.Time________ff = oldTick.Time________ff;
            tick.Volume = oldTick.Volume;
            tick.Turnover = oldTick.Turnover;
            tick.OpenInterest = oldTick.OpenInterest;
            tick.LastPrice = oldTick.LastPrice;
            tick.AveragePrice = oldTick.AveragePrice;

            return tick;
        }
    }
}
