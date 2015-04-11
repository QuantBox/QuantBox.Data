using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V2
{
    public class Int2DoubleConverter
    {
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
            field.ContractMultiplier = config.ContractMultiplier;
            field.Time_ssf_Diff = config.Time_ssf_Diff;
            field.MarketDepth = config.MarketDepth;
            field.MarketType = config.MarketType;
            field.Volume_Total_Or_Increment = config.Volume_Total_Or_Increment;
            field.Turnover_Total_Or_Increment = config.Turnover_Total_Or_Increment;

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
            field.PreClose = split.PreClose;
            //field.AdjustingFactor = split.AdjustingFactor;

            return field;
        }

        public List<DepthItemView> Int2Double(List<DepthItem> oldList, bool descending)
        {
            if (oldList == null || oldList.Count == 0)
                return null;

            List<DepthItemView> newList = new List<DepthItemView>();

            foreach(var o in oldList)
            {
                newList.Add(new DepthItemView() {
                    Price = Codec.TickToPrice(o.Price),
                    Size = o.Size,
                    Count = o.Count,
                });
            }

            if (descending)
            {
                newList.Reverse();
            }

            return newList;
        }

        public PbTickView Int2Double(PbTick tick, bool descending)
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

            field.Turnover = Codec.GetTurnover(tick);
            field.AveragePrice = Codec.GetAveragePrice(tick);

            field.LastPrice = Codec.TickToPrice(tick.LastPrice);
            field.AskPrice1 = Codec.TickToPrice(tick.AskPrice1);

            
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
            field.DepthList = Int2Double(tick.DepthList, descending);

            return field;
        }
    }
}
