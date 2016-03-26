namespace QuantBox.Data.Serializer.V2
{
    public class DepthItem
    {
        public int Price;
        public int Size;
        public int Count;

        public DepthItem()
        {

        }

        public DepthItem(int price, int size, int count)
        {
            Price = price;
            Size = size;
            Count = count;
        }

        public bool IsZero
        {
            get
            {
                return Price == 0
                       && Size == 0
                       && Count == 0;
            }
        }
    }
}