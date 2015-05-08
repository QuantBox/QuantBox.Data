namespace QuantBox.Data.Serializer.V2
{
    public class StockSplitInfoView
    {
        public double CashDividend { get; set; }
        public double StockDividend { get; set; }
        public double RightsOffering { get; set; }
        public double RightsOfferingPrice { get; set; }

        public double PreClose { get; set; }
        public double AdjustingFactor { get; set; }
    }
}