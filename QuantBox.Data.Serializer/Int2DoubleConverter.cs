using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer
{
    public class Int2DoubleConverter
    {
        private bool flat = true;
        public Int2DoubleConverter(bool flat)
        {
            this.flat = flat;
        }

        public PbTickCodec Codec;
        public BarInfoView Int2Double(BarInfo bar)
        {
            if (bar == null)
                return null;

            BarInfoView field = new BarInfoView();
            
            field.Open = Codec.TickToPrice(bar.Open);
            field.High = Codec.TickToPrice(bar.High);
            field.Low = Codec.TickToPrice(bar.Low);
            field.Close = Codec.TickToPrice(bar.Close);
            field.BarSize = bar.BarSize;

            return field;
        }

        public StaticInfoView Int2Double(StaticInfo Static)
        {
            if (Static == null)
                return null;

            StaticInfoView field = new StaticInfoView();

            field.LowerLimitPrice = Codec.GetLowerLimitPrice(Static);
            field.UpperLimitPrice = Codec.GetUpperLimitPrice(Static);
            field.SettlementPrice = Codec.GetSettlementPrice(Static);

            field.Symbol = Static.Symbol;
            field.Exchange = Static.Exchange;
            field.Multiplier = Static.Multiplier;

            return field;
        }

        public ConfigInfoView Int2Double(ConfigInfo config)
        {
            if (config == null)
                return null;

            ConfigInfoView field = new ConfigInfoView();

            field.Version = config.Version;
            field.TickSize = config.TickSize;
            field.TickSizeMultiplier = config.TickSizeMultiplier;
            field.SettlementPriceMultiplier = config.SettlementPriceMultiplier;
            field.AveragePriceMultiplier = config.AveragePriceMultiplier;
            field.TurnoverMultiplier = config.TurnoverMultiplier;
            field.Time_ssf_Diff = config.Time_ssf_Diff;

            return field;
        }

        public StockSplitInfoView Int2Double(StockSplitInfo split)
        {
            if (split == null)
                return null;

            StockSplitInfoView field = new StockSplitInfoView();

            field.CashDividend = split.CashDividend;
            field.StockDividend = split.StockDividend;
            field.RightsOffering = split.RightsOffering;
            field.RightsOfferingPrice = split.RightsOfferingPrice;
            field.AdjustingFactor = split.AdjustingFactor;

            return field;
        }

        public DepthTickView Int2Double(DepthTick depthTick)
        {
            if (depthTick == null)
                return null;

            DepthTickView field = new DepthTickView();

            field.BidPrice1 = Codec.TickToPrice(depthTick.BidPrice1);
            field.BidSize1 = depthTick.BidSize1;
            field.AskPrice1 = Codec.TickToPrice(depthTick.AskPrice1);
            field.AskSize1 = depthTick.AskSize1;
            field.BidPrice2 = Codec.TickToPrice(depthTick.BidPrice2);
            field.BidSize2 = depthTick.BidSize2;
            field.AskPrice2 = Codec.TickToPrice(depthTick.AskPrice2);
            field.AskSize2 = depthTick.AskSize2;
            field.BidPrice3 = Codec.TickToPrice(depthTick.BidPrice3);
            field.BidSize3 = depthTick.BidSize3;
            field.AskPrice3 = Codec.TickToPrice(depthTick.AskPrice3);
            field.AskSize3 = depthTick.AskSize3;

            if (depthTick.Next != null)
                field.Next = Int2Double(depthTick.Next);

            field.BidCount1 = depthTick.BidCount1;
            field.AskCount1 = depthTick.AskCount1;
            field.BidCount2 = depthTick.BidCount2;
            field.AskCount2 = depthTick.AskCount2;
            field.BidCount3 = depthTick.BidCount3;
            field.AskCount3 = depthTick.AskCount3;

            return field;
        }

        public PbTickView Int2Double(PbTick tick)
        {
            if (tick == null)
                return null;

            PbTickView field = new PbTickView();
            
            // 利用此机会设置TickSize
            if(Codec == null)
            {
                Codec = new PbTickCodec();
            }
            field.Config = Int2Double(tick.Config);

            Codec.Config = tick.Config;
            Codec.UseFlat(flat);

            field.Turnover = Codec.GetTurnover(tick);
            field.AveragePrice = Codec.GetAveragePrice(tick);

            field.LastPrice = Codec.TickToPrice(tick.LastPrice);

            field.Depth1_3 = Int2Double(tick.Depth1_3);
            field.Volume = tick.Volume;
            field.OpenInterest = tick.OpenInterest;
            
            field.TradingDay = tick.TradingDay;
            field.ActionDay = tick.ActionDay;
            field.Time_HHmm = tick.Time_HHmm;
            field.Time_____ssf__ = tick.Time_____ssf__;
            field.Time________ff = tick.Time________ff;

            field.Bar = Int2Double(tick.Bar);
            field.Static = Int2Double(tick.Static);
            field.Split = Int2Double(tick.Split);

            return field;
        }

        #region 深度行情的显示方式转换
        public static List<DepthDetailView> ToList(DepthTickView deep)
        {
            List<DepthDetailView> list = new List<DepthDetailView>();
            DepthDetailView detail;

            DepthTickView last = deep;
            while (last != null)
            {
                if (last.BidSize1 == 0 || last.AskSize1 == 0)
                    break;

                detail = new DepthDetailView();
                detail.BidPrice = last.BidPrice1;
                detail.BidSize = last.BidSize1;
                detail.BidCount = last.BidCount1;
                detail.AskPrice = last.AskPrice1;
                detail.AskSize = last.AskSize1;
                detail.AskCount = last.AskCount1;
                list.Add(detail);

                if (last.BidSize2 == 0 || last.AskSize2 == 0)
                    break;

                detail = new DepthDetailView();
                detail.BidPrice = last.BidPrice2;
                detail.BidSize = last.BidSize2;
                detail.BidCount = last.BidCount2;
                detail.AskPrice = last.AskPrice2;
                detail.AskSize = last.AskSize2;
                detail.AskCount = last.AskCount2;
                list.Add(detail);

                if (last.BidSize3 == 0 || last.AskSize3 == 0)
                    break;

                detail = new DepthDetailView();
                detail.BidPrice = last.BidPrice3;
                detail.BidSize = last.BidSize3;
                detail.BidCount = last.BidCount3;
                detail.AskPrice = last.AskPrice3;
                detail.AskSize = last.AskSize3;
                detail.AskCount = last.AskCount3;
                list.Add(detail);

                last = last.Next;
            }

            return list;
        }

        public static DepthTickView FromList(List<DepthDetailView> list)
        {
            if (list == null || list.Count == 0)
                return null;

            DepthTickView first = null;
            DepthTickView next = null;

            for(int i=0;i<list.Count;++i)
            {
                DepthDetailView detail = list[i];
                switch(i%3)
                {
                    case 0:
                        if(next == null)
                        {
                            next = new DepthTickView();
                            first = next;
                        }
                        else
                        {
                            next.Next = new DepthTickView();
                            next = next.Next;
                        }

                        next.BidPrice1 = detail.BidPrice;
                        next.BidSize1 = detail.BidSize;
                        next.BidCount1 = detail.BidCount;
                        next.AskPrice1 = detail.AskPrice;
                        next.AskSize1 = detail.AskSize;
                        next.AskCount1 = detail.AskCount;
                        break;
                    case 1:
                        next.BidPrice2 = detail.BidPrice;
                        next.BidSize2 = detail.BidSize;
                        next.BidCount2 = detail.BidCount;
                        next.AskPrice2 = detail.AskPrice;
                        next.AskSize2 = detail.AskSize;
                        next.AskCount2 = detail.AskCount;
                        break;
                    case 2:
                        next.BidPrice3 = detail.BidPrice;
                        next.BidSize3 = detail.BidSize;
                        next.BidCount3 = detail.BidCount;
                        next.AskPrice3 = detail.AskPrice;
                        next.AskSize3 = detail.AskSize;
                        next.AskCount3 = detail.AskCount;
                        break;
                }
            }

            return first;
        }
        #endregion
    }
}
