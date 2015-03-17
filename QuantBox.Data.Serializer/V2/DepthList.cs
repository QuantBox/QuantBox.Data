using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Price = price;
            this.Size = size;
            this.Count = count;
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

    public class DepthList
    {
        // 一定要关闭才行
        // 1.只有买价，先AddStart(1),然后SetAsk(2),SetEnd(2)
        // 2.只有卖价，先AddStart(1),然后SetAsk(1),SetEnd(2)
        // 3.啥都没有，先AddStart(1),然后SetAsk(1),SetEnd(1)
        public int Start;
        public int AskPrice1;
        public int End;
        
        public List<DepthItem> List = new List<DepthItem>();

        public void AddStart(int price,int size,int count)
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

    public class DepthListHelper
    {
        #region List中的算法操作
        public static void ExpandTwoListsToSameLength(List<DepthItem> oldPrevList,List<DepthItem> oldCurrList,int StartPrice,int EndPrice,List<DepthItem> newPrevList,List<DepthItem> newCurrList)
        {
            newPrevList.Clear();
            newCurrList.Clear();

            if (oldPrevList == null)
                oldPrevList = new List<DepthItem>();
            if (oldCurrList == null)
                oldCurrList = new List<DepthItem>();

            DepthItem prevItem = null;
            DepthItem currItem = null;

            // 从新一条记录开始算起
            int i = 0;
            int j = 0;
            for (; i < oldCurrList.Count; ++i)
            {
                currItem = oldCurrList[i];
                
                // 处理新列表中数据的范围
                if (currItem.Price < StartPrice)
                    continue;
                if (currItem.Price > EndPrice)
                    break;

                for (; j < oldPrevList.Count; ++j)
                {
                    prevItem = oldPrevList[j];


                    if (prevItem.Price < StartPrice)
                        continue;
                    // 条件是&&的原因是curr在范围内，而prev在范围外的情况会出现
                    if (prevItem.Price > EndPrice && currItem.Price > EndPrice)
                        break;

                    if(currItem.Price == prevItem.Price)
                    {
                        // 两边都有,直接两边都复制
                        newPrevList.Add(prevItem);
                        newCurrList.Add(currItem);
                        
                        // 这样将两个指针都向后移动
                        ++j;
                        break;
                    }
                    else if (currItem.Price < prevItem.Price)
                    {
                        // 新序列的价格小，按新的复制，然后将新的指针向后移动
                        newCurrList.Add(currItem);
                        newPrevList.Add(new DepthItem() { Price = currItem.Price});
                        break;
                    }
                    else
                    {
                        // 老的价格小，按老的复制，然后继续遍历老序列
                        newPrevList.Add(prevItem);
                        newCurrList.Add(new DepthItem() { Price = prevItem.Price });
                    }
                }

                // 历史的已经刷完，当前的还有
                if(j == oldPrevList.Count)
                {
                    if (currItem.Price > EndPrice)
                        break;

                    // 只有新数据，没有老数据的情况
                    if(prevItem == null || currItem.Price>prevItem.Price)
                    {
                        newCurrList.Add(currItem);
                        newPrevList.Add(new DepthItem() { Price = currItem.Price });
                    }
                }
            }
            // 当前的已经刷完，去刷历史了
            for (; j < oldPrevList.Count; ++j)
            {
                prevItem = oldPrevList[j];

                // 只有历史没有最新
                if (prevItem.Price < StartPrice)
                    continue;
                if (prevItem.Price > EndPrice)
                    break;

                newPrevList.Add(prevItem);
                newCurrList.Add(new DepthItem() { Price = prevItem.Price });
            }
            
        }
        public static void SizeMinusInTwoLists(List<DepthItem> oldPrevList, List<DepthItem> oldCurrList, List<DepthItem> newList)
        {
            if(oldPrevList.Count != oldCurrList.Count)
            {
                
            }

            newList.Clear();
            for (int i = 0; i < oldPrevList.Count; ++i)
            {
                DepthItem prevItem = oldPrevList[i];
                DepthItem currItem = oldCurrList[i];
                newList.Add(new DepthItem(currItem.Price, currItem.Size - prevItem.Size, currItem.Count - prevItem.Count));
            }
        }

        public static void SizeAddInTwoLists(List<DepthItem> oldPrevList, List<DepthItem> oldCurrList, List<DepthItem> newList)
        {
            if (oldPrevList.Count != oldCurrList.Count)
            {

            }

            newList.Clear();
            for (int i = 0; i < oldPrevList.Count; ++i)
            {
                DepthItem prevItem = oldPrevList[i];
                DepthItem currItem = oldCurrList[i];
                // 为0的跳过，减少无效的显示
                int size = currItem.Size + prevItem.Size;
                if (size != 0)
                    newList.Add(new DepthItem(currItem.Price, size, currItem.Count + prevItem.Count));
            }
        }

        public static void PriceMinusInOneList(List<DepthItem> oldList, List<DepthItem> newList)
        {
            newList.Clear();
            
            DepthItem prevItem = null;

            for (int i = 0; i < oldList.Count; ++i)
            {
                DepthItem currItem = oldList[i];
                // 这里为0的丢弃
                if (currItem.Size == 0)
                    continue;

                if(prevItem == null)
                {
                    newList.Add(currItem);
                }
                else
                {
                    newList.Add(new DepthItem(currItem.Price - prevItem.Price - 1, currItem.Size, currItem.Count));
                }

                prevItem = currItem;
            }
        }

        public static void PriceAddInOneList(List<DepthItem> oldList, List<DepthItem> newList)
        {
            newList.Clear();

            DepthItem prevItem = null;

            for (int i = 0; i < oldList.Count; ++i)
            {
                DepthItem currItem = oldList[i];

                if (prevItem == null)
                {
                    prevItem = currItem;
                    newList.Add(currItem);
                }
                else
                {
                    prevItem = new DepthItem(currItem.Price + prevItem.Price + 1, currItem.Size, currItem.Count);
                    newList.Add(prevItem);
                }
            }
        }
        #endregion

        #region List到结构体的转换
        public static int GetDepthTick14(DepthTick tick, int pos)
        {
            DepthTick from_next = tick;

            switch (pos)
            {
                case 1:
                    return from_next.Value1;
                case 2:
                    return from_next.Value2;
                case 3:
                    return from_next.Value3;
                case 4:
                    return from_next.Value4;
                case 5:
                    return from_next.Value5;
                case 6:
                    return from_next.Value6;
                case 7:
                    return from_next.Value7;
                case 8:
                    return from_next.Value8;
                case 9:
                    return from_next.Value9;
                case 10:
                    return from_next.Value10;
                case 11:
                    return from_next.Value11;
                case 12:
                    return from_next.Value12;
                case 13:
                    return from_next.Value13;
                case 14:
                    return from_next.Value14;
            }
            return 0;
        }

        public static void SetDepthTick14(DepthTick tick, int pos, int value)
        {
            DepthTick from_next = tick;
            switch (pos)
            {
                case 1:
                    from_next.Value1 = value;
                    break;
                case 2:
                    from_next.Value2 = value;
                    break;
                case 3:
                    from_next.Value3 = value;
                    break;
                case 4:
                    from_next.Value4 = value;
                    break;
                case 5:
                    from_next.Value5 = value;
                    break;
                case 6:
                    from_next.Value6 = value;
                    break;
                case 7:
                    from_next.Value7 = value;
                    break;
                case 8:
                    from_next.Value8 = value;
                    break;
                case 9:
                    from_next.Value9 = value;
                    break;
                case 10:
                    from_next.Value10 = value;
                    break;
                case 11:
                    from_next.Value11 = value;
                    break;
                case 12:
                    from_next.Value12 = value;
                    break;
                case 13:
                    from_next.Value13 = value;
                    break;
                case 14:
                    from_next.Value14 = value;
                    break;
            }
        }

        public static void SetDepthTick(DepthTick tick, int pos, int value)
        {
            DepthTick from_next = tick;

            while (pos > 0)
            {
                if (from_next == null)
                    return;

                if (pos <= 14)
                {
                    SetDepthTick14(from_next, pos, value);
                }

                pos -= 14;

                if (pos > 0)
                {
                    if (from_next.Next == null)
                        from_next.Next = new DepthTick();
                    from_next = from_next.Next;
                }
            }
        }

        public static int GetDepthTick(DepthTick tick, int pos)
        {
            DepthTick from_next = tick;

            while (pos > 0)
            {
                if (from_next == null)
                    return 0;

                if (pos <= 14)
                {
                    return GetDepthTick14(from_next, pos);
                }

                pos -= 14;

                if (pos > 0)
                {
                    if (from_next.Next == null)
                        return 0;
                    from_next = from_next.Next;
                }
            }

            return 0;
        }

        public static void ListToStruct(List<DepthItem> list, int dataCount, DepthTick tick)
        {
            int pos = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                DepthItem currItem = list[i];

                switch (dataCount)
                {
                    case 1:
                        SetDepthTick(tick, ++pos, currItem.Price);
                        break;
                    case 2:
                        SetDepthTick(tick, ++pos, currItem.Price);
                        SetDepthTick(tick, ++pos, currItem.Size);
                        break;
                    case 3:
                        SetDepthTick(tick, ++pos, currItem.Price);
                        SetDepthTick(tick, ++pos, currItem.Size);
                        SetDepthTick(tick, ++pos, currItem.Count);
                        break;
                }
            }
        }

        public static void StructToList(DepthTick tick, int dataCount, List<DepthItem> list)
        {
            list.Clear();

            DepthTick from_next = tick;

            DepthItem item = null;
            int pos = 0;

            while (from_next != null)
            {
                for (int i = 1; i <= 14; ++i)
                {
                    ++pos;
                    if (dataCount == 3)
                    {
                        switch (pos % dataCount)
                        {
                            case 1:
                                item = new DepthItem();
                                item.Price = GetDepthTick14(from_next, i);
                                break;
                            case 2:
                                item.Size = GetDepthTick14(from_next, i);
                                break;
                            case 0:
                                item.Count = GetDepthTick14(from_next, i);
                                list.Add(item);
                                break;
                        }
                    }
                    else if (dataCount == 2)
                    {
                        switch (pos % dataCount)
                        {
                            case 1:
                                item = new DepthItem();
                                item.Price = GetDepthTick14(from_next, i);
                                break;
                            case 0:
                                item.Size = GetDepthTick14(from_next, i);
                                list.Add(item);
                                break;
                        }
                    }
                    else if (dataCount == 1)
                    {
                        switch (pos % dataCount)
                        {
                            case 0:
                                item = new DepthItem();
                                item.Price = GetDepthTick14(from_next, i);
                                list.Add(item);
                                break;
                        }
                    }
                }

                // 指向下一个可用数据
                from_next = from_next.Next;
            }

            // 由于上面结构的特点，最后会有些数据为空的内容加入,要删去
            for (int j = list.Count - 1; j >= 0; --j)
            {
                if (list[j].IsZero)
                {
                    list.RemoveAt(j);
                }
                else
                {
                    break;
                }
            }
        }
        #endregion


        /// <summary>
        /// 只处理价格是正确的数据
        /// 如何处理
        /// 只有卖价，0，即第一个位置就是卖一
        /// 只有买价，=list.count，比如说count=2,那买一价就是list.count-1=1
        /// 都没有，list.count=0;-1
        /// </summary>
        /// <param name="list"></param>
        /// <param name="AskPrice1"></param>
        /// <returns></returns>
        public static int FindAsk1Position(List<DepthItem> list,int AskPrice1)
        {
            if (list.Count == 0)
                return -1;

            int i = 0;
            for (; i < list.Count;++i )
            {
                DepthItem currItem = list[i];
                if(currItem.Price >= AskPrice1)
                {
                    break;
                }
            }
            return i;
        }

        public static int FindAsk1Position(List<DepthItemView> list, double AskPrice1)
        {
            if (list.Count == 0)
                return -1;

            int i = 0;
            for (; i < list.Count; ++i)
            {
                DepthItemView currItem = list[i];
                if (currItem.Price >= AskPrice1)
                {
                    break;
                }
            }
            return i;
        }
    }
}
