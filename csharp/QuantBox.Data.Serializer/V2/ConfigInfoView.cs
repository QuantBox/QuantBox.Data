namespace QuantBox.Data.Serializer.V2
{
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
}