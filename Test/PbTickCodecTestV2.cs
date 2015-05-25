using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using QuantBox.Data.Serializer.V2;

namespace Test
{
    [TestClass]
    public class PbTickCodecTestV2
    {
        [TestMethod]
        public void Test2List()
        {

        }

        static void Main(string[] args)
        {
            List<DepthItem> oldPrevList = new List<DepthItem>();
            List<DepthItem> oldCurrList = new List<DepthItem>();

            List<DepthItem> newPrevList = new List<DepthItem>();
            List<DepthItem> newCurrList = new List<DepthItem>();

            DepthListHelper test = new DepthListHelper();
            
            // 处理老的多一条
            oldPrevList.Add(new DepthItem(1, 100, 0));
            oldPrevList.Add(new DepthItem(7, 100, 0));
            oldPrevList.Add(new DepthItem(12, 100, 0));

            int j11 = DepthListHelper.FindAsk1Position(oldPrevList, 0);
            int j12 = DepthListHelper.FindAsk1Position(oldPrevList, 1);
            int j13 = DepthListHelper.FindAsk1Position(oldPrevList, 12);
            int j14 = DepthListHelper.FindAsk1Position(oldPrevList, 15);

            List<DepthItemView> oldPrevListV = new List<DepthItemView>();
            oldPrevListV.Add(new DepthItemView() { Price = 10});
            oldPrevListV.Add(new DepthItemView() { Price = 5 });
            oldPrevListV.Add(new DepthItemView() { Price = 1 });

            int j21 = DepthListHelper.FindAsk1PositionDescending(oldPrevListV, 12);
            int j22 = DepthListHelper.FindAsk1PositionDescending(oldPrevListV, 10);
            int j23 = DepthListHelper.FindAsk1PositionDescending(oldPrevListV, 1);
            int j24 = DepthListHelper.FindAsk1PositionDescending(oldPrevListV, 0);

            //oldCurrList.Add(new DepthItem(5, 100, 0));
            //oldCurrList.Add(new DepthItem(8, 100, 0));
            //oldCurrList.Add(new DepthItem(13, 100, 0));
            
            DepthListHelper.ExpandTwoListsToSameLength(oldPrevList, oldCurrList, 5, 13, newPrevList, newCurrList);

            List<DepthItem> newList = new List<DepthItem>();

            DepthListHelper.SizeMinusInTwoLists(newPrevList, newCurrList, newList);

            List<DepthItem> newList2 = new List<DepthItem>();

            DepthListHelper.SizeAddInTwoLists(newPrevList, newList, newList2);

            List<DepthItem> newList3 = new List<DepthItem>();

            DepthListHelper.PriceMinusInOneList(newList2, newList3);

            List<DepthItem> newList4 = new List<DepthItem>();

            DepthListHelper.PriceAddInOneList(newList3, newList4);

            DepthTick tick = new DepthTick();

            DepthListHelper.SetDepthTick(tick, 4, 100);
            DepthListHelper.SetDepthTick(tick, 10, 200);
            DepthListHelper.SetDepthTick(tick, 15, 300);
            DepthListHelper.SetDepthTick(tick, 28, 400);
            DepthListHelper.SetDepthTick(tick, 30, 500);

            int i1 = DepthListHelper.GetDepthTick(tick, 4);
            int i2 = DepthListHelper.GetDepthTick(tick, 10);
            int i3 = DepthListHelper.GetDepthTick(tick, 15);
            int i4 = DepthListHelper.GetDepthTick(tick, 28);
            int i5 = DepthListHelper.GetDepthTick(tick, 30);
            int i6 = DepthListHelper.GetDepthTick(tick, 45);

            DepthTick tick2 = new DepthTick();

            DepthListHelper.ListToStruct(newPrevList, 2, tick2);

            List<DepthItem> newList5 = new List<DepthItem>();

            DepthListHelper.StructToList(tick2, 2, newList5);


            //int j1 = test.FindAsk1Position(oldCurrList, 5);

            //int j2 = test.FindAsk1Position(oldCurrList, 8);
            //int j3 = test.FindAsk1Position(oldCurrList, 12);
            //int j4 = test.FindAsk1Position(oldCurrList, 13);

            //int j5 = test.FindAsk1Position(oldCurrList, 14);
            //int j6 = test.FindAsk1Position(oldCurrList, 15);

            //int j7 = test.FindAsk1Position(oldCurrList, 4);
            //int j8 = test.FindAsk1Position(oldCurrList, 7);


            //oldPrevList = new List<DepthItem>();
            //oldPrevList.Add(new DepthItem(3, 100, 0));
            //oldPrevList.Add(new DepthItem(7, 100, 0));
            //oldPrevList.Add(new DepthItem(12, 100, 0));
            //int x1 = test.FindAsk1Position(oldPrevList, 3);
            //int x2 = test.FindAsk1Position(oldPrevList, 7);
            //int x3 = test.FindAsk1Position(oldPrevList, 12);
            //int x4 = test.FindAsk1Position(oldPrevList, 5);
            //int x5 = test.FindAsk1Position(oldPrevList, 13);
            //int x6 = test.FindAsk1Position(oldPrevList, 2);




            // 处理新的多一条
            //oldPrevList.Add(new DepthItem(1, 100, 0));

            //oldCurrList.Add(new DepthItem(1, 100, 0));
            //oldCurrList.Add(new DepthItem(5, 100, 0));

            //test.Do(oldPrevList, oldCurrList, newPrevList, newCurrList);

            //test.
        }

        static void Main2(string[] args)
        {
             //读五档行情，然后存盘
            FileInfo fi = new FileInfo(@"d:\wukan\Desktop\20141225.csv");
            //FileInfo fo = new FileInfo(@"d:\wukan\Desktop\20141225.pd0");

            PbTickSerializer pts = new PbTickSerializer();


            using (Stream stream = File.Open(@"d:\wukan\Desktop\20141225_1.pd0", FileMode.Create))
            {
                using (StreamReader file = new StreamReader(fi.OpenRead()))
                {
                    int i = 0;
                    string str = file.ReadLine();
                    do
                    {
                        ++i;
                        str = file.ReadLine();
                        if (str == null)
                            break;

                        string[] arr = str.Split(',');

                        PbTick tick = new PbTick();

                        pts.Codec.SetSymbol(tick, arr[0]);

                        tick.Config = new ConfigInfo().Default();

                        if (arr[0].StartsWith("TF"))
                        {
                            tick.Config.SetTickSize(0.002);
                            tick.Config.ContractMultiplier = 10000;
                        }
                        else
                        {
                            tick.Config.SetTickSize(0.2);
                            tick.Config.ContractMultiplier = 300;
                        }
                        tick.Config.Time_ssf_Diff = 5;

                        pts.Codec.Config = tick.Config;


                        tick.ActionDay = int.Parse(arr[5]);
                        int time = int.Parse(arr[6]);

                        tick.Time_HHmm = time / 100000;
                        tick.Time_____ssf__ = time % 100000 / 100;
                        tick.Time________ff = time % 100;

                        pts.Codec.SetLastPrice(tick, double.Parse(arr[8]));
                        pts.Codec.SetHigh(tick, double.Parse(arr[9]));
                        pts.Codec.SetLow(tick, double.Parse(arr[10]));
                        pts.Codec.SetVolume(tick, int.Parse(arr[11]));
                        pts.Codec.SetTurnover(tick, int.Parse(arr[12]));

                        pts.Codec.SetOpenInterest(tick, int.Parse(arr[16]));


                        tick.DepthList = new List<DepthItem>();

                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[31])), int.Parse(arr[36]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[30])), int.Parse(arr[35]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[29])), int.Parse(arr[34]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[28])), int.Parse(arr[33]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[27])), int.Parse(arr[32]), 0));

                        pts.Codec.SetAskPrice1(tick, double.Parse(arr[17]));

                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[17])), int.Parse(arr[22]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[18])), int.Parse(arr[23]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[19])), int.Parse(arr[24]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[20])), int.Parse(arr[25]), 0));
                        tick.DepthList.Add(new DepthItem(pts.Codec.PriceToTick(double.Parse(arr[21])), int.Parse(arr[26]), 0));


                        pts.Write(tick,  stream);

                    } while (str != null);
                    file.Close();
                }
            }
        }


        class AAA
        {
            public string symbol;
            public string time;
            public bool buy;
            public double price;
            public int size;
        }

        class BBB
        {
            public double TickSize = 1000;
            public string symbol;
            public string time;
            private List<AAA> Asks = new List<AAA>(); // 先存数字大的，后存数字小的，最后是卖一
            private List<AAA> Bids = new List<AAA>(); // 先存数字大的，后存数字小的，最前是买一
            public PbTick tick;
            public PbTickCodec Codec = new PbTickCodec();

            public void AddAsk(AAA a)
            {
                // 由小到大
                if (Asks.Count > 1)
                {
                    double diff = a.price - Asks[Asks.Count - 1].price;
                    if (diff > 0)
                        TickSize = Codec.gcd(TickSize, diff);
                }
                else
                {
                    TickSize = Codec.gcd(TickSize, a.price);
                }
                Asks.Add(a);
            }

            public void AddBid(AAA b)
            {
                // 由大到小
                if (Bids.Count > 1)
                {
                    double diff = Bids[Bids.Count - 1].price - b.price;
                    if (diff > 0)
                        TickSize = Codec.gcd(TickSize, diff);
                }
                else
                {
                    TickSize = Codec.gcd(TickSize, b.price);
                }
                Bids.Add(b);
            }

            public void CalcTickSize()
            {
                if (Bids.Count > 1 && Asks.Count > 1)
                {
                    double ts3 = Asks[0].price - Bids[Bids.Count - 1].price;
                    if (ts3 > 0)
                    {
                        TickSize = Codec.gcd(TickSize, ts3);
                    }
                }
            }

            public void MakeTick()
            {
                tick = new PbTick();
                tick.Config = new ConfigInfo().Default();

                CalcTickSize();

                tick.Config.SetTickSize(TickSize);
                tick.Config.Time_ssf_Diff = 10;


                Codec.Config = tick.Config;

                int HH = int.Parse(time.Substring(0, 2));
                int mm = int.Parse(time.Substring(3, 2));
                int ss = int.Parse(time.Substring(6, 2));

                tick.Time_HHmm = HH * 100 + mm;
                tick.Time_____ssf__ = ss * 10;

                tick.TradingDay = 20150120;

                //if()
                //{

                //}
                tick.DepthList = new List<DepthItem>();

                int i = 0;
                Bids.Reverse();
                foreach (var b in Bids)
                {
                    tick.DepthList.Add(new DepthItem(Codec.PriceToTick(b.price), b.size, 0));
                }

                foreach (var a in Asks)
                {
                    tick.DepthList.Add(new DepthItem(Codec.PriceToTick(a.price), a.size, 0));
                }
                if(Asks.Count>0)
                {
                    Codec.SetAskPrice1(tick, Asks[0].price);
                }
                Codec.SetSymbol(tick, symbol);
            }

            public void Reset()
            {
                Asks = null;
                Bids = null;
            }
        }

        class CCC
        {
            public Dictionary<string, BBB> dict = new Dictionary<string, BBB>();
            public Dictionary<string, PbTickSerializer> dict2 = new Dictionary<string, PbTickSerializer>();
            public Dictionary<string, Stream> dict3 = new Dictionary<string, Stream>();

            public BBB Get(string symbol)
            {
                BBB list;
                if (!dict.TryGetValue(symbol, out list))
                {
                    list = new BBB();
                    dict.Add(symbol, list);
                }
                return list;
            }

            public PbTickSerializer GetSerializer(string symbol)
            {
                PbTickSerializer list;
                if (!dict2.TryGetValue(symbol, out list))
                {
                    list = new PbTickSerializer();
                    dict2.Add(symbol, list);
                }
                return list;
            }

            public Stream GetStream(string symbol)
            {
                Stream list;
                if (!dict3.TryGetValue(symbol, out list))
                {
                    list = File.Open(@"F:\办公文档\数据\DepthDataShow\" + symbol + ".pd0", FileMode.Create);
                    dict3.Add(symbol, list);
                }
                return list;
            }
        }

        static void Main3(string[] args)
        {
            FileInfo fi = new FileInfo(@"F:\办公文档\数据\DepthDataShow\20150120.txt");
            //FileInfo fo = new FileInfo(@"F:\BaiduYunDownload\DepthDataShow\20150120.pd0");

            PbTickSerializer pts = new PbTickSerializer();

            CCC ccc = new CCC();
            CCC last_ccc = new CCC();

            AAA last = new AAA();
            last.buy = false;

            string last_symbol = "XXX";

            List<AAA> list = new List<AAA>();

            //using (Stream stream = File.Open(@"F:\BaiduYunDownload\DepthDataShow\20150120.pd0", FileMode.Create))
            {
                using (StreamReader file = new StreamReader(fi.OpenRead()))
                {
                    int i = 0;
                    string str;
                    do
                    {
                        ++i;
                        str = file.ReadLine();
                        if (str == null)
                            break;

                        string[] arr = str.Split(',');

                        AAA a = new AAA();
                        a.symbol = arr[1];
                        a.buy = arr[2] == "0";
                        a.price = double.Parse(arr[3]);
                        a.size = int.Parse(arr[4]);


                        if (last.buy == false && a.buy == true)
                        {
                            // 快照的切换点，把上次的存储都取出来，进行保存
                            // sell里先存的数字大的，后存的数字小的,最后的是卖一
                            // buy里也是先存数字大的，后存数字小的，最前的买一
                            // 
                            foreach (var kv in ccc.dict)
                            {
                                kv.Value.MakeTick();

                                ccc.GetSerializer(kv.Key).Write(kv.Value.tick,
                                    ccc.GetStream(kv.Key));
                            }

                            ccc.dict.Clear();
                        }

                        BBB bbb = ccc.Get(a.symbol);
                        bbb.symbol = a.symbol;
                        bbb.time = arr[0];

                        if (bbb.symbol == "cu1502")
                        {
                            int nTest = 1;
                        }

                        if (a.buy)
                        {
                            bbb.AddBid(a);
                        }
                        else
                        {
                            bbb.AddAsk(a);
                        }


                        last = a;
                        last_symbol = a.symbol;

                        //if (i < 4000)
                        //    Console.WriteLine(str);
                        //if (i > 1000)
                        //    break;
                    } while (str != null);
                    file.Close();
                }
            }
        }
    }
}
