using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V2
{
    public class Double2IntConverter
    {
        public PbTickCodec Codec;
        public BarInfo Double2Int(BarInfoView bar)
        {
            if (bar == null)
                return null;

            BarInfo field = new BarInfo();
            
            field.Open = Codec.PriceToTick(bar.Open);
            field.High = Codec.PriceToTick(bar.High);
            field.Low = Codec.PriceToTick(bar.Low);
            field.Close = Codec.PriceToTick(bar.Close);
            field.BarSize = bar.BarSize;

            return field;
        }

        public StaticInfo Double2Int(StaticInfoView Static)
        {
            if (Static == null)
                return null;

            StaticInfo field = new StaticInfo();
            
            Codec.SetLowerLimitPrice(field, Static.LowerLimitPrice);
            Codec.SetUpperLimitPrice(field, Static.UpperLimitPrice);
            Codec.SetSettlementPrice(field, Static.SettlementPrice);

            field.Symbol = Static.Symbol;
            field.Exchange = Static.Exchange;

            return field;
        }

        public ConfigInfo Double2Int(ConfigInfoView config)
        {
            if (config == null)
                return null;

            ConfigInfo field = new ConfigInfo();

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

        public StockSplitInfo Double2Int(StockSplitInfoView split)
        {
            if (split == null)
                return null;

            StockSplitInfo field = new StockSplitInfo();

            field.CashDividend = split.CashDividend;
            field.StockDividend = split.StockDividend;
            field.RightsOffering = split.RightsOffering;
            field.RightsOfferingPrice = split.RightsOfferingPrice;
            field.PreClose = split.PreClose;
            //field.AdjustingFactor = split.AdjustingFactor;

            return field;
        }

        public List<DepthItem> Double2Int(List<DepthItemView> oldList, bool descending)
        {
            if (oldList == null || oldList.Count == 0)
                return null;

            List<DepthItem> newList = new List<DepthItem>();

            foreach (var o in oldList)
            {
                newList.Add(new DepthItem()
                {
                    Price = Codec.PriceToTick(o.Price),
                    Size = o.Size,
                    Count = o.Count,
                });
            }

            if(descending)
            {
                newList.Reverse();
            }

            return newList;
        }

        public PbTick Double2Int(PbTickView tick, bool descending)
        {
            if (tick == null)
                return null;

            PbTick field = new PbTick();

            // 利用此机会设置TickSize
            if (Codec == null)
            {
                Codec = new PbTickCodec();
            }
            field.Config = Double2Int(tick.Config);

            Codec.Config = field.Config;

            Codec.SetTurnover(field, tick.Turnover);
            Codec.SetAveragePrice(field, tick.AveragePrice);

            field.LastPrice = Codec.PriceToTick(tick.LastPrice);
            field.AskPrice1 = Codec.PriceToTick(tick.AskPrice1);

            field.Volume = tick.Volume;
            field.OpenInterest = tick.OpenInterest;

            field.TradingDay = tick.TradingDay;
            field.ActionDay = tick.ActionDay;
            field.Time_HHmm = tick.Time_HHmm;
            field.Time_____ssf__ = tick.Time_____ssf__;
            field.Time________ff = tick.Time________ff;

            field.Bar = Double2Int(tick.Bar);
            field.Static = Double2Int(tick.Static);
            field.Split = Double2Int(tick.Split);
            field.DepthList = Double2Int(tick.DepthList, descending);

            return field;
        }
    }
}
