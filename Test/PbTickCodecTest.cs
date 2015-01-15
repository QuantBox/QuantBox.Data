using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantBox.Data.Serializer;
using System.IO;

namespace Test
{
    [TestClass]
    public class PbTickCodecTest
    {
        

        [TestMethod]
        public void TestConvertDateTime()
        {
            var span = new TimeSpan(0, 12, 34, 56, 789);
            int time = 123456;
            int ms = 789;

            int hhmm_____ = 0;
            int ____ssf__ = 0;
            int _______ff = 0;

            var codec = new PbTickCodec();

            codec.SetUpdateTime(span, out hhmm_____, out ____ssf__, out _______ff);
            Assert.AreEqual<int>(1234, hhmm_____);
            Assert.AreEqual<int>(567, ____ssf__);
            Assert.AreEqual<int>(89, _______ff);

            codec.SetUpdateTime(time, ms, out hhmm_____, out ____ssf__, out _______ff);
            Assert.AreEqual<int>(1234, hhmm_____);
            Assert.AreEqual<int>(567, ____ssf__);
            Assert.AreEqual<int>(89, _______ff);

            codec.GetUpdateTime(hhmm_____, ____ssf__, _______ff, out time, out ms);
            Assert.AreEqual<int>(123456, time);
            Assert.AreEqual<int>(789, ms);

            span = codec.GetUpdateTime(hhmm_____, ____ssf__, _______ff);
            Assert.AreEqual<int>(0, span.Days);
            Assert.AreEqual<int>(12, span.Hours);
            Assert.AreEqual<int>(34, span.Minutes);
            Assert.AreEqual<int>(56, span.Seconds);
            Assert.AreEqual<int>(789, span.Milliseconds);

            var date1 = 20141104;
            var date2 = 20141105;

            var tick = new PbTick();
            codec.SetActionDay(tick, new DateTime(2014, 11, 4));
            codec.SetTradingDay(tick, new DateTime(2014, 11, 5));
            Assert.AreEqual<int>(date1, tick.ActionDay);
            Assert.AreEqual<int>(date2, tick.TradingDay);
            Assert.AreEqual<DateTime>(new DateTime(2014, 11, 4), codec.GetDateTime(tick.ActionDay));
            Assert.AreEqual<DateTime>(new DateTime(2014, 11, 5), codec.GetDateTime(tick.TradingDay));
        }

        [TestMethod]
        public void TestGetSetPrice()
        {
            PbTickCodec codec = new PbTickCodec();

            codec.Config.SetTickSize(0.2);
            codec.UseFlat(false);

            PbTick tick = new PbTick();

            Assert.AreEqual<double>(0, codec.GetBidPrice(tick, 1));
            Assert.AreEqual<double>(0, codec.GetBidPrice(tick, 4));
            Assert.AreEqual<double>(0, codec.GetBidPrice(tick, 10));

            codec.SetBidPrice(tick, 1, 1.0);
            codec.SetBidPrice(tick, 4, 2.4);
            codec.SetBidPrice(tick, 10, 5.8);

            Assert.AreEqual<double>(1, codec.GetBidPrice(tick, 1));
            Assert.AreEqual<double>(2.4, codec.GetBidPrice(tick, 4));
            Assert.AreEqual<double>(5.8, codec.GetBidPrice(tick, 10));



            Assert.AreEqual<double>(0, codec.GetAskPrice(tick, 1));
            Assert.AreEqual<double>(0, codec.GetAskPrice(tick, 4));
            Assert.AreEqual<double>(0, codec.GetAskPrice(tick, 10));

            codec.SetAskPrice(tick, 1, -1.0);
            codec.SetAskPrice(tick, 4, 2.4);
            codec.SetAskPrice(tick, 10, -5.8);

            Assert.AreEqual<double>(-1.0, codec.GetAskPrice(tick, 1));
            Assert.AreEqual<double>(2.4, codec.GetAskPrice(tick, 4));
            Assert.AreEqual<double>(-5.8, codec.GetAskPrice(tick, 10));

            codec.SetAskCount(tick, 1, 4);
            codec.SetAskCount(tick, 4, 5);
            codec.SetAskCount(tick, 10, -9);

            Assert.AreEqual<double>(4, codec.GetAskCount(tick, 1));
            Assert.AreEqual<double>(5, codec.GetAskCount(tick, 4));
            Assert.AreEqual<double>(-9, codec.GetAskCount(tick, 10));

            codec.SetSettlementPrice(tick, 1234.56);
            Assert.AreEqual<double>(1234.56, codec.GetSettlementPrice(tick), "SettlementPrice");

            codec.SetTurnover(tick, 4567.89);
            Assert.AreEqual<double>(0, codec.GetTurnover(tick), "Turnover");
        }

        [TestMethod]
        public void TestTick2Price()
        {
            PbTickCodec ptc = new PbTickCodec();

            ptc.Config.SetTickSize(0.2);
            ptc.UseFlat(false);

            Assert.AreEqual<int>(5, ptc.PriceToTick(1));
            Assert.AreEqual<int>(6, ptc.PriceToTick(1.2));
            Assert.AreEqual<int>(7, ptc.PriceToTick(1.4));
            Assert.AreEqual<int>(8, ptc.PriceToTick(1.6));
            Assert.AreEqual<int>(9, ptc.PriceToTick(1.8));
            Assert.AreEqual<int>(10, ptc.PriceToTick(2.0));

            Assert.AreEqual<int>(-5, ptc.PriceToTick(-1));
            Assert.AreEqual<int>(-6, ptc.PriceToTick(-1.2));
            Assert.AreEqual<int>(-7, ptc.PriceToTick(-1.4));
            Assert.AreEqual<int>(-8, ptc.PriceToTick(-1.6));
            Assert.AreEqual<int>(-9, ptc.PriceToTick(-1.8));
            Assert.AreEqual<int>(-10, ptc.PriceToTick(-2.0));


            Assert.AreEqual<double>(0.2, ptc.TickToPrice(1));
            Assert.AreEqual<double>(0.4, ptc.TickToPrice(2));

            Assert.AreEqual<double>(-0.2, ptc.TickToPrice(-1));
            Assert.AreEqual<double>(-0.4, ptc.TickToPrice(-2));
            Assert.AreEqual<double>(-2, ptc.TickToPrice(-10));
        }

        [TestMethod]
        public void TestTickDiff()
        {
            PbTickCodec codec = new PbTickCodec();

            codec.Config.SetTickSize(0.2);
            codec.Config.Time_ssf_Diff = 5;
            codec.UseFlat(false);

            PbTick tick1 = new PbTick();

            tick1.Config = codec.Config;

            codec.SetLastPrice(tick1, 1234);
            codec.SetVolume(tick1, 1);
            codec.SetActionDay(tick1, DateTime.Today);
            codec.SetTradingDay(tick1, DateTime.Today.AddDays(-1));
            //codec.Set
            codec.SetAskPrice(tick1, 1, 1234.2);
            codec.SetAskSize(tick1, 1, 1);
            //codec.SetAskPrice(tick1, 2, 1234.4);
            //codec.SetAskSize(tick1, 2, 1);
            //codec.SetAskPrice(tick1, 3, 1234.6);
            //codec.SetAskSize(tick1, 3, 3);
            //codec.SetAskPrice(tick1, 4, 1234.8);
            //codec.SetAskSize(tick1, 4, 4);
            //codec.SetAskPrice(tick1, 5, 1235.0);
            //codec.SetAskSize(tick1, 5, 5);
            //codec.SetAskPrice(tick1, 6, 1235.2);
            //codec.SetAskSize(tick1, 6, 6);

            codec.SetBidPrice(tick1, 1, 1234);
            codec.SetBidSize(tick1, 1, 1);
            //codec.SetBidPrice(tick1, 2, 1233.8);
            //codec.SetBidSize(tick1, 2, 2);
            //codec.SetBidPrice(tick1, 3, 1233.6);
            //codec.SetBidSize(tick1, 3, 3);
            //codec.SetBidPrice(tick1, 4, 1233.4);
            //codec.SetBidSize(tick1, 4, 4);
            //codec.SetBidPrice(tick1, 5, 1233.2);
            //codec.SetBidSize(tick1, 5, 5);
            //codec.SetBidPrice(tick1, 6, 1232.0);
            //codec.SetBidSize(tick1, 6, 6);

            codec.SetLowerLimitPrice(tick1, 123.4);
            codec.SetUpperLimitPrice(tick1, 567.8);
            codec.SetSettlementPrice(tick1, 123.4);

            codec.SetOpen(tick1, 10);
            codec.SetHigh(tick1, 10);
            codec.SetLow(tick1, 10);
            codec.SetClose(tick1, 10);
            codec.SetBarSize(tick1, 10);

            tick1.Time_HHmm = 1234;
            tick1.Time_____ssf__ = 567;
            tick1.Time________ff = 0;

            PbTick tick2 = new PbTick();
            codec.SetLastPrice(tick2, 1234.2);
            codec.SetVolume(tick2, 2);

            codec.SetActionDay(tick2, DateTime.Today);
            codec.SetTradingDay(tick2, DateTime.Today.AddDays(-1));
            codec.SetAskPrice(tick2, 1, 1234.2);
            codec.SetAskSize(tick2, 1, 1);
            codec.SetAskPrice(tick2, 2, 1234.4);
            codec.SetAskSize(tick2, 2, 2);
            codec.SetAskPrice(tick2, 3, 1234.6);
            codec.SetAskSize(tick2, 3, 3);

            codec.SetBidPrice(tick2, 1, 1234);
            codec.SetBidSize(tick2, 1, 1);
            codec.SetBidPrice(tick2, 2, 1233.8);
            codec.SetBidSize(tick2, 2, 2);
            codec.SetBidPrice(tick2, 3, 1233.6);
            codec.SetBidSize(tick2, 3, 3);

            codec.SetLowerLimitPrice(tick2, 123.4);
            codec.SetUpperLimitPrice(tick2, 567.8);
            codec.SetSettlementPrice(tick2, 123.4);

            codec.SetOpen(tick2, 10);
            codec.SetHigh(tick2, 10);
            codec.SetLow(tick2, 10);
            codec.SetClose(tick2, 10);
            codec.SetBarSize(tick2, 10);

            tick2.Time_HHmm = 1234;
            tick2.Time_____ssf__ = 572;
            tick2.Time________ff = 0;

            var diff = codec.Diff(tick1, tick2);

            Assert.AreEqual<int>(0, diff.ActionDay);
            Assert.AreEqual<int>(0, diff.TradingDay);
            Assert.AreEqual(null, diff.Static);
            Assert.AreEqual(null, diff.Bar);
            Assert.AreEqual<int>(0, diff.Depth1_3.AskPrice1, "AskPrice1");
            Assert.AreEqual<int>(0, diff.Depth1_3.AskSize1, "AskSize1");
            Assert.AreEqual<int>(0, diff.Depth1_3.AskPrice2, "AskPrice2");
            Assert.AreEqual<int>(2, diff.Depth1_3.AskSize2, "AskSize2");
            Assert.AreEqual<int>(0, diff.Depth1_3.AskPrice3, "AskPrice3");
            Assert.AreEqual<int>(3, diff.Depth1_3.AskSize3, "AskSize3");

            Assert.AreEqual<int>(0, diff.Time_____ssf__);


            var tick3 = codec.Restore(tick1, diff);

            Assert.AreEqual<int>(tick2.Depth1_3.AskPrice1, tick3.Depth1_3.AskPrice1);
            Assert.AreEqual<int>(tick2.Depth1_3.AskPrice2, tick3.Depth1_3.AskPrice2);
            Assert.AreEqual<int>(tick2.Depth1_3.AskPrice3, tick3.Depth1_3.AskPrice3);
            Assert.AreEqual<int>(tick2.Depth1_3.AskSize1, tick3.Depth1_3.AskSize1);
            Assert.AreEqual<int>(tick2.Depth1_3.AskSize2, tick3.Depth1_3.AskSize2);
            Assert.AreEqual<int>(tick2.Depth1_3.AskSize3, tick3.Depth1_3.AskSize3);

            Assert.AreEqual<int>(tick2.Depth1_3.BidPrice1, tick3.Depth1_3.BidPrice1);
            Assert.AreEqual<int>(tick2.Depth1_3.BidPrice2, tick3.Depth1_3.BidPrice2);
            Assert.AreEqual<int>(tick2.Depth1_3.BidPrice3, tick3.Depth1_3.BidPrice3);
            Assert.AreEqual<int>(tick2.Depth1_3.BidSize1, tick3.Depth1_3.BidSize1);
            Assert.AreEqual<int>(tick2.Depth1_3.BidSize2, tick3.Depth1_3.BidSize2);
            Assert.AreEqual<int>(tick2.Depth1_3.BidSize3, tick3.Depth1_3.BidSize3);

            Assert.AreEqual<double>(codec.GetLowerLimitPrice(tick1), codec.GetLowerLimitPrice(tick3));
            Assert.AreEqual<double>(codec.GetUpperLimitPrice(tick1), codec.GetUpperLimitPrice(tick3));
            Assert.AreEqual<double>(codec.GetSettlementPrice(tick1), codec.GetSettlementPrice(tick3));

            Assert.AreEqual<double>(codec.GetOpen(tick1), codec.GetOpen(tick3));
            Assert.AreEqual<double>(codec.GetHigh(tick1), codec.GetHigh(tick3));
            Assert.AreEqual<double>(codec.GetLow(tick1), codec.GetLow(tick3));
            Assert.AreEqual<double>(codec.GetClose(tick1), codec.GetClose(tick3));

            Assert.AreEqual<int>(572, tick3.Time_____ssf__);
        }

        [TestMethod]
        public void TestTickMultiplier()
        {
            PbTickCodec codec = new PbTickCodec();

            codec.Config.SetTickSize(0.2);
            codec.Config.Time_ssf_Diff = 5;
            codec.UseFlat(false);

            PbTick tick1 = new PbTick();
            codec.SetAveragePrice(tick1, 123.45);
            codec.SetSettlementPrice(tick1, 123.45);
            codec.SetTurnover(tick1, 1234567890123456);
            codec.SetOpenInterest(tick1, 9123456789012345678);
            codec.SetVolume(tick1, 1234567890);

            

            Assert.AreEqual<double>(123.45, codec.GetAveragePrice(tick1));
            Assert.AreEqual<double>(123.45, codec.GetSettlementPrice(tick1));
            Assert.AreEqual<double>(1234567890120000, codec.GetTurnover(tick1));
            Assert.AreEqual<long>(9123456789012345678, codec.GetOpenInterest(tick1));
            Assert.AreEqual<long>(1234567890, codec.GetVolume(tick1));

            codec.Config.TurnoverMultiplier = 1;
            codec.SetTurnover(tick1, 1234567890123456);
            Assert.AreEqual<double>(1234567890123456, codec.GetTurnover(tick1));

            codec.Config.TurnoverMultiplier = 0.01;
            codec.SetTurnover(tick1, 12345678901234.56);
            Assert.AreEqual<double>(12345678901234.56, codec.GetTurnover(tick1));
        }

        [TestMethod]
        public void TestGcdTickSize()
        {
            PbTickCodec codec = new PbTickCodec();

            Assert.AreEqual<double>(0.00001, codec.gcd());
            Assert.AreEqual<double>(0.3, codec.gcd(100.3f - 100.0f));
            Assert.AreEqual<double>(0.2, codec.gcd(100.3f - 100.1f));
            Assert.AreEqual<double>(0.1, codec.gcd(100.3f - 100.0f, 100.2f - 100.0f));
            Assert.AreEqual<double>(0.1, codec.gcd(100.3f - 100.0f, 100.2f - 100.0f, 100.1f - 100.0f));
            Assert.AreEqual<double>(0.05, codec.gcd(100.3f - 100.0f, 100.2f - 100.0f, 100.1f - 100.0f, 100.1f - 100.05f));

            Assert.AreEqual<double>(0.1, codec.gcd(100.0f - 100.3f, 100.0f - 100.2f));
            Assert.AreEqual<double>(0.05, codec.gcd(100.0f - 100.3f, 100.0f - 100.2f, 100.0f - 100.1f, 100.05f - 100.1f));
        }

        [TestMethod]
        public void TestStatic()
        {
            PbTickCodec codec = new PbTickCodec();

            codec.Config.SetTickSize(0.2);
            codec.UseFlat(false);


            PbTick tick1 = new PbTick();

            tick1.Config = codec.Config;

            codec.SetMultiplier(tick1, 1234);
            codec.SetSymbol(tick1, "ABC");
            codec.SetExchange(tick1, "DEF");

            PbTick tick2 = new PbTick();
            codec.SetMultiplier(tick2, 1234);
            codec.SetSymbol(tick2, "ABC");
            codec.SetExchange(tick2, "DEF");

            var diff = codec.Diff(tick1, tick2);

            Assert.AreEqual(null, diff.Static);
        }

        //[TestMethod]
        //public void TestDataFile()
        //{
        //    //var stream = new MemoryStream(File.ReadAllBytes("test.data"));
        //    //var serializer = new PbTickSerializer();
        //    //PbTick raw;
        //    //var tick = serializer.Read(stream, out raw);

        //    //Assert.AreNotEqual(null, tick);
        //}

        [TestMethod]
        public void TestReadCsvLeve1()
        {
            FileInfo fi = new FileInfo(@"d:\wukan\Desktop\if_all\IF1406.csv");
            FileInfo fo = new FileInfo(@"d:\wukan\Desktop\if_all\IF1406.data");

            PbTickSerializer pts = new PbTickSerializer();
            pts.Codec.Config.SetTickSize(0.2);
            pts.Codec.Config.Time_ssf_Diff = 5;

            using (Stream stream = File.OpenWrite(@"d:\wukan\Desktop\if_all\IF1406.data"))
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

                        DateTime dt = DateTime.Parse(arr[0]).AddMilliseconds(int.Parse(arr[1]));
                        string symbol = arr[2];
                        double price = double.Parse(arr[3]);
                        int vol = int.Parse(arr[4]);
                        int openint = int.Parse(arr[5]);
                        double bid = double.Parse(arr[6]);
                        int bidSize = int.Parse(arr[7]);
                        double ask = double.Parse(arr[8]);
                        int askSize = int.Parse(arr[9]);

                        PbTick tick = new PbTick();

                        tick.Config = pts.Codec.Config;

                        pts.Codec.SetLastPrice(tick, price);
                        pts.Codec.SetVolume(tick, vol);
                        pts.Codec.SetSymbol(tick, symbol);

                        pts.Codec.SetActionDay(tick, dt.Date);
                        pts.Codec.SetUpdateTime(tick, dt - dt.Date);

                        pts.Codec.SetBidPrice(tick, 1, bid);
                        pts.Codec.SetBidSize(tick, 1, bidSize);
                        pts.Codec.SetAskPrice(tick, 1, ask);
                        pts.Codec.SetAskSize(tick, 1, askSize);

                        pts.Write(tick, new Stream[] { stream });

                        //if (i == 1000000)
                        //    break;

                    } while (str != null);
                    file.Close();
                }
            }
            Console.WriteLine("结束了");
        }

        [TestMethod]
        public void TestReadCsvLeve2()
        {
            FileInfo fi = new FileInfo(@"D:\wukan\Desktop\20141225\20141225.csv");
            FileInfo fo = new FileInfo(@"D:\wukan\Desktop\20141225\20141225.data");

            PbTickSerializer pts = new PbTickSerializer();


            using (Stream stream = File.OpenWrite(@"D:\wukan\Desktop\20141225\20141225.data"))
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
                        }
                        else
                        {
                            tick.Config.SetTickSize(0.2);
                        }
                        tick.Config.Time_ssf_Diff = 5;
                        tick.Config.TurnoverMultiplier = 1;

                        pts.Codec.Config = tick.Config;
                        pts.Codec.UseFlat(false);

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

                        pts.Codec.SetAskPrice(tick, 1, double.Parse(arr[17]));
                        pts.Codec.SetAskPrice(tick, 2, double.Parse(arr[18]));
                        pts.Codec.SetAskPrice(tick, 3, double.Parse(arr[19]));
                        pts.Codec.SetAskPrice(tick, 4, double.Parse(arr[20]));
                        pts.Codec.SetAskPrice(tick, 5, double.Parse(arr[21]));

                        pts.Codec.SetAskSize(tick, 1, int.Parse(arr[22]));
                        pts.Codec.SetAskSize(tick, 2, int.Parse(arr[23]));
                        pts.Codec.SetAskSize(tick, 3, int.Parse(arr[24]));
                        pts.Codec.SetAskSize(tick, 4, int.Parse(arr[25]));
                        pts.Codec.SetAskSize(tick, 5, int.Parse(arr[26]));

                        pts.Codec.SetBidPrice(tick, 1, double.Parse(arr[27]));
                        pts.Codec.SetBidPrice(tick, 2, double.Parse(arr[28]));
                        pts.Codec.SetBidPrice(tick, 3, double.Parse(arr[29]));
                        pts.Codec.SetBidPrice(tick, 4, double.Parse(arr[30]));
                        pts.Codec.SetBidPrice(tick, 5, double.Parse(arr[31]));

                        pts.Codec.SetBidSize(tick, 1, int.Parse(arr[32]));
                        pts.Codec.SetBidSize(tick, 2, int.Parse(arr[33]));
                        pts.Codec.SetBidSize(tick, 3, int.Parse(arr[34]));
                        pts.Codec.SetBidSize(tick, 4, int.Parse(arr[35]));
                        pts.Codec.SetBidSize(tick, 5, int.Parse(arr[36]));

                        pts.Write(tick, new Stream[] { stream });

                    } while (str != null);
                    file.Close();
                }
            }
        }
    }
}
