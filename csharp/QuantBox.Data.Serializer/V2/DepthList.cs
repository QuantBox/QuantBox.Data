using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V2
{
    public class DepthList
    {
        // 一定要关闭才行
        // 1.只有买价，先AddStart(1),然后SetAsk(2),SetEnd(2)
        // 2.只有卖价，先AddStart(1),然后SetAsk(1),SetEnd(2)
        // 3.啥都没有，先AddStart(1),然后SetAsk(1),SetEnd(1)
        public int Start;
        public int AskPrice1;
        public int End;

        public readonly List<DepthItem> List = new List<DepthItem>();

        public void AddStart(int price, int size, int count)
        {
            List.Clear();
            List.Add(new DepthItem(price, size, count));
            Start = price;
        }

        public void Add(int price, int size, int count)
        {
            List.Add(new DepthItem(price, size, count));
        }

        public void SetAskPrice1(int price)
        {
            AskPrice1 = price;
        }

        public void SetEnd(int price)
        {
            End = price;
        }
    }
}
