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

            var field = new BarInfoView();

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

            var field = new StaticInfoView();

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

            var field = new ConfigInfoView();

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

            var field = new StockSplitInfoView();

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

            var newList = new List<DepthItemView>();

            foreach (var o in oldList) {
                newList.Add(new DepthItemView() {
                    Price = Codec.TickToPrice(o.Price),
                    Size = o.Size,
                    Count = o.Count,
                });
            }

            if (descending) {
                newList.Reverse();
            }

            return newList;
        }

        public PbTickView Int2Double(PbTick tick, bool descending)
        {
            if (tick == null)
                return null;

            var view = new PbTickView();

            // 利用此机会设置TickSize
            if (Codec == null) {
                Codec = new PbTickCodec();
            }
            view.Config = Int2Double(tick.Config);

            Codec.Config = tick.Config;

            view.Turnover = Codec.GetTurnover(tick);
            view.AveragePrice = Codec.GetAveragePrice(tick);

            view.LastPrice = Codec.TickToPrice(tick.LastPrice);
            view.AskPrice1 = Codec.TickToPrice(tick.AskPrice1);
            
            view.Volume = tick.Volume;
            view.OpenInterest = tick.OpenInterest;

            view.TradingDay = tick.TradingDay;
            view.ActionDay = tick.ActionDay;
            view.Time_HHmm = tick.Time_HHmm;
            view.Time_____ssf__ = tick.Time_____ssf__;
            view.Time________ff = tick.Time________ff;

            view.Bar = Int2Double(tick.Bar);
            view.Static = Int2Double(tick.Static);
            view.Split = Int2Double(tick.Split);
            view.LocalTime_Msec = tick.LocalTime_Msec;
            view.DepthList = Int2Double(tick.DepthList, descending);
            view.LoadQuote(descending);
            return view;
        }
    }
}
