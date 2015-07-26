namespace QuantBox.Data.Serializer.V2
{
    public class BarInfoView
    {
        /// <summary>
        /// 与上一笔的Open比较
        /// </summary>
        public double Open { get; set; }
        /// <summary>
        /// 与上一笔的High比较
        /// </summary>
        public double High { get; set; }
        /// <summary>
        /// 与上一笔的Low比较
        /// </summary>
        public double Low { get; set; }
        /// <summary>
        /// 与上一笔的Close比较
        /// </summary>
        public double Close { get; set; }
        /// <summary>
        /// 与上一笔的BarSize比较
        /// </summary>
        public int BarSize { get; set; }
    }
}