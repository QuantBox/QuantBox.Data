namespace QuantBox.Data.Serializer.V2
{
    public class DepthItemView
    {
        public double Price { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }

        public string ToCsvHeader()
        {
            return "Price,Size,Count";
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",
                Price, Size, Count);
        }
    }
}