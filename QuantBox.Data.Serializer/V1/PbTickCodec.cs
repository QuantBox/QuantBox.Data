using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantBox.Data.Serializer.V1
{
    public class PbTickCodec
    {
        private ConfigInfo _config;
        private ConfigInfo config_flat;
        public ConfigInfo Config { get; set; }

        private double TickSize;

        public PbTickCodec()
        {
            Config = new ConfigInfo().Default();
            config_flat = new ConfigInfo().Flat();

            UseFlat(false);
        }

        public void UseFlat(bool flat)
        {
            if(flat)
            {
                _config = config_flat;
            }
            else
            {
                _config = Config;
            }
            TickSize = _config.GetTickSize();
        }

        static long gcd(long a, long b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }

        public double gcd(params double[] val)
        {
            // 先用把浮点变成整数才能做GCD
            double TickSizeMultiplier = 100000;

            if (val.Length == 0)
                return 1 / TickSizeMultiplier;

            long a = (long)Math.Round(Math.Abs(val[0]) * TickSizeMultiplier, 0);

            if (val.Length > 1)
            {
                for (int i = 1; i < val.Length; ++i)
                {
                    var b = (long)Math.Round(Math.Abs(val[i]) * TickSizeMultiplier, 0);
                    a = gcd(a, b);
                }
            }
            return a / TickSizeMultiplier;
        }

        public void SetAveragePrice(PbTick tick, double price)
        {
            tick.AveragePrice = PriceToTick(price * _config.AveragePriceMultiplier);
        }
        public double GetAveragePrice(PbTick tick)
        {
            return (TickToPrice(tick.AveragePrice) / _config.AveragePriceMultiplier);
        }

        public void SetTurnover(PbTick tick, double val)
        {
            tick.Turnover = (long)(val / _config.TurnoverMultiplier);
        }
        public double GetTurnover(PbTick tick)
        {
            return tick.Turnover * _config.TurnoverMultiplier;
        }

        public void SetOpenInterest(PbTick tick, long val)
        {
            tick.OpenInterest = val;
        }
        public long GetOpenInterest(PbTick tick)
        {
            return tick.OpenInterest;
        }
        public void SetVolume(PbTick tick, long val)
        {
            tick.Volume = val;
        }
        public long GetVolume(PbTick tick)
        {
            return tick.Volume;
        }

        #region Bar部分处理
        public void SetOpen(BarInfo Bar, double price)
        {
            Bar.Open = PriceToTick(price);
        }
        public void SetOpen(PbTick tick, double price)
        {
            if (tick.Bar == null)
                tick.Bar = new BarInfo();
            SetOpen(tick.Bar, price);
        }

        public double GetOpen(BarInfo Bar)
        {
            if (Bar == null)
                return 0;

            return TickToPrice(Bar.Open);
        }

        public double GetOpen(PbTick tick)
        {
            return GetOpen(tick.Bar);
        }

        public void SetHigh(BarInfo Bar, double price)
        {
            Bar.High = PriceToTick(price);
        }

        public void SetHigh(PbTick tick, double price)
        {
            if (tick.Bar == null)
                tick.Bar = new BarInfo();
            SetHigh(tick.Bar, price);
        }

        public double GetHigh(BarInfo Bar)
        {
            if (Bar == null)
                return 0;

            return TickToPrice(Bar.High);
        }

        public double GetHigh(PbTick tick)
        {
            return GetHigh(tick.Bar);
        }

        public void SetLow(BarInfo Bar, double price)
        {
            Bar.Low = PriceToTick(price);
        }

        public void SetLow(PbTick tick, double price)
        {
            if (tick.Bar == null)
                tick.Bar = new BarInfo();
            SetLow(tick.Bar, price);
        }

        public double GetLow(BarInfo Bar)
        {
            if (Bar == null)
                return 0;

            return TickToPrice(Bar.Low);
        }

        public double GetLow(PbTick tick)
        {
            return GetLow(tick.Bar);
        }

        public void SetClose(BarInfo Bar, double price)
        {
            Bar.Close = PriceToTick(price);
        }

        public void SetClose(PbTick tick, double price)
        {
            if (tick.Bar == null)
                tick.Bar = new BarInfo();
            SetClose(tick.Bar, price);
        }

        public double GetClose(BarInfo Bar)
        {
            if (Bar == null)
                return 0;

            return TickToPrice(Bar.Close);
        }

        public double GetClose(PbTick tick)
        {
            return GetClose(tick.Bar);
        }

        public void SetBarSize(BarInfo Bar, int barSize)
        {
            Bar.BarSize = barSize;
        }

        public void SetBarSize(PbTick tick, int barSize)
        {
            if (tick.Bar == null)
                tick.Bar = new BarInfo();
            SetBarSize(tick.Bar, barSize);
        }

        public int GetBarSize(BarInfo Bar)
        {
            if (Bar == null)
                return 0;

            return Bar.BarSize;
        }

        public int GetBarSize(PbTick tick)
        {
            return GetBarSize(tick.Bar);
        }
        #endregion

        #region Static部分处理
        public void SetSettlementPrice(StaticInfo Static, double price)
        {
            Static.SettlementPrice = PriceToTick(price * _config.SettlementPriceMultiplier);
        }

        public void SetSettlementPrice(PbTick tick, double price)
        {
            if (tick.Static == null)
                tick.Static = new StaticInfo();
            SetSettlementPrice(tick.Static, price);
        }

        public double GetSettlementPrice(StaticInfo Static)
        {
            if (Static == null)
                return 0;

            return (TickToPrice(Static.SettlementPrice) / _config.SettlementPriceMultiplier);
        }

        public double GetSettlementPrice(PbTick tick)
        {
            return GetSettlementPrice(tick.Static);
        }

        public void SetLowerLimitPrice(StaticInfo Static, double price)
        {
            Static.LowerLimitPrice = PriceToTick(price);
        }

        public void SetLowerLimitPrice(PbTick tick, double price)
        {
            if (tick.Static == null)
                tick.Static = new StaticInfo();
            SetLowerLimitPrice(tick.Static, price);
        }

        public double GetLowerLimitPrice(StaticInfo Static)
        {
            if (Static == null)
                return 0;

            return TickToPrice(Static.LowerLimitPrice);
        }

        public double GetLowerLimitPrice(PbTick tick)
        {
            return GetLowerLimitPrice(tick.Static);
        }

        public void SetUpperLimitPrice(StaticInfo Static, double price)
        {
            Static.UpperLimitPrice = PriceToTick(price);
        }

        public void SetUpperLimitPrice(PbTick tick, double price)
        {
            if (tick.Static == null)
                tick.Static = new StaticInfo();
            SetUpperLimitPrice(tick.Static, price);
        }

        public double GetUpperLimitPrice(StaticInfo Static)
        {
            if (Static == null)
                return 0;

            return TickToPrice(Static.UpperLimitPrice);
        }

        public double GetUpperLimitPrice(PbTick tick)
        {
            return GetUpperLimitPrice(tick.Static);
        }

        public void SetSymbol(PbTick tick, string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return;

            if (tick.Static == null)
                tick.Static = new StaticInfo();

            tick.Static.Symbol = val;
        }
        public string GetSymbol(PbTick tick)
        {
            if (tick.Static == null)
                return null;

            return tick.Static.Symbol;
        }

        public void SetExchange(PbTick tick, string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                return;

            if (tick.Static == null)
                tick.Static = new StaticInfo();

            tick.Static.Exchange = val;
        }
        public string GetExchange(PbTick tick)
        {
            if (tick.Static == null)
                return null;

            return tick.Static.Exchange;
        }
        #endregion

        #region Tick1_3档处理
        public DepthTick CreateLevelObject(PbTick tick, int level)
        {
            if (level <= 0)
            {
                throw new InvalidOperationException("the level must be gt zero");
            }

            DepthTick from_last = null;
            DepthTick from_next = null;

            from_last = null;
            from_next = tick.Depth1_3;

            while (level > 0)
            {
                if (from_next == null)
                {
                    from_next = new DepthTick();
                }

                if (from_last == null)
                {
                    tick.Depth1_3 = from_next;
                }
                else
                {
                    from_last.Next = from_next;
                }

                from_last = from_next;
                from_next = from_next.Next;

                level -= 3;
            }

            return from_last;
        }

        public DepthTick GetLevelObject(PbTick tick, int level)
        {
            if (level <= 0)
            {
                throw new InvalidOperationException("the level must be gt zero");
            }

            DepthTick from_last = null;
            DepthTick from_next = null;

            from_last = null;
            from_next = tick.Depth1_3;

            while (level > 0)
            {
                if (from_next == null)
                {
                    return null;
                }

                from_last = from_next;
                from_next = from_next.Next;

                level -= 3;
            }

            return from_last;
        }

        public void SetBidPrice(PbTick tick, int level, double price)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.BidPrice1 = PriceToTick(price);
                    break;
                case 2:
                    next.BidPrice2 = PriceToTick(price);
                    break;
                case 0:
                    next.BidPrice3 = PriceToTick(price);
                    break;
            }
        }

        public double GetBidPrice(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return TickToPrice(next.BidPrice1);
                case 2:
                    return TickToPrice(next.BidPrice2);
                case 0:
                    return TickToPrice(next.BidPrice3);
            }
            return 0;
        }

        public void SetAskPrice(PbTick tick, int level, double price)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.AskPrice1 = PriceToTick(price);
                    break;
                case 2:
                    next.AskPrice2 = PriceToTick(price);
                    break;
                case 0:
                    next.AskPrice3 = PriceToTick(price);
                    break;
            }
        }

        public double GetAskPrice(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return TickToPrice(next.AskPrice1);
                case 2:
                    return TickToPrice(next.AskPrice2);
                case 0:
                    return TickToPrice(next.AskPrice3);
            }
            return 0;
        }

        public void SetBidSize(PbTick tick, int level, int size)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.BidSize1 = size;
                    break;
                case 2:
                    next.BidSize2 = size;
                    break;
                case 0:
                    next.BidSize3 = size;
                    break;
            }
        }

        public int GetBidSize(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return next.BidSize1;
                case 2:
                    return next.BidSize2;
                case 0:
                    return next.BidSize3;
            }
            return 0;
        }

        public void SetAskSize(PbTick tick, int level, int size)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.AskSize1 = size;
                    break;
                case 2:
                    next.AskSize2 = size;
                    break;
                case 0:
                    next.AskSize3 = size;
                    break;
            }
        }

        public int GetAskSize(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return next.AskSize1;
                case 2:
                    return next.AskSize2;
                case 0:
                    return next.AskSize3;
            }
            return 0;
        }

        public void SetBidCount(PbTick tick, int level, int count)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.BidCount1 = count;
                    break;
                case 2:
                    next.BidCount2 = count;
                    break;
                case 0:
                    next.BidCount3 = count;
                    break;
            }
        }

        public int GetBidCount(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return next.BidCount1;
                case 2:
                    return next.BidCount2;
                case 0:
                    return next.BidCount3;
            }
            return 0;
        }

        public void SetAskCount(PbTick tick, int level, int count)
        {
            var next = CreateLevelObject(tick, level);

            switch (level % 3)
            {
                case 1:
                    next.AskCount1 = count;
                    break;
                case 2:
                    next.AskCount2 = count;
                    break;
                case 0:
                    next.AskCount3 = count;
                    break;
            }
        }

        public int GetAskCount(PbTick tick, int level)
        {
            var next = GetLevelObject(tick, level);
            if (next == null)
                return 0;

            switch (level % 3)
            {
                case 1:
                    return next.AskCount1;
                case 2:
                    return next.AskCount2;
                case 0:
                    return next.AskCount3;
            }
            return 0;
        }
        #endregion

        #region 时间处理
        public void SetTradingDay(PbTick tick, DateTime date)
        {
            tick.TradingDay = SetDateTime(date);
        }

        public int SetDateTime(DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

        public DateTime GetDateTime(int date)
        {
            var year = date / 10000;
            var month = (date % 10000) / 100;
            var day = date % 100;
            return new DateTime(year, month, day);
        }

        public DateTime GetTradingDayDateTime(PbTick tick)
        {
            return GetDateTime(tick.TradingDay) + GetUpdateTime(tick);
        }

        public DateTime GetActionDayDateTime(PbTick tick)
        {
            return GetDateTime(tick.ActionDay) + GetUpdateTime(tick);
        }

        public void SetActionDay(PbTick tick, DateTime date)
        {
            tick.ActionDay = SetDateTime(date);
        }

        public void SetUpdateTime(int time, int ms, out int hhmm_____, out int ____ssf__, out int _______ff)
        {
            // 由于肯定Millisec这个每次都会变，0变5，2变7，如果让他127内变不就更合适？
            // 时间123456，只取前面的1234，到分钟，然后相减，也就是分钟变一次
            // 时间123456.200，只取562，然后相减，也就是最大是599变成0,一般情况是变5
            int t = time * 1000 + ms;
            hhmm_____ = t / 100000;
            ____ssf__ = t % 100000 / 100;
            _______ff = t % 100;
        }

        public void SetUpdateTime(TimeSpan span, out int hhmm_____, out int ____ssf__, out int _______ff)
        {
            var time = span.Hours * 10000 + span.Minutes * 100 + span.Seconds;
            SetUpdateTime(time, span.Milliseconds, out hhmm_____, out ____ssf__, out _______ff);
        }

        public void SetUpdateTime(PbTick tick, int Time, int Millisec)
        {
            SetUpdateTime(Time, Millisec, out tick.Time_HHmm, out tick.Time_____ssf__, out tick.Time________ff);
        }

        public void SetUpdateTime(PbTick tick, TimeSpan span)
        {
            SetUpdateTime(span, out tick.Time_HHmm, out tick.Time_____ssf__, out tick.Time________ff);
        }

        public void GetUpdateTime(int hhmm, int ssf, int ff, out int time, out int ms)
        {
            time = (hhmm * 1000 + ssf) / 10;
            ms = (ssf % 10) * 100 + ff;
        }

        public void GetUpdateTime(PbTick tick, out int time, out int ms)
        {
            GetUpdateTime(tick.Time_HHmm, tick.Time_____ssf__, tick.Time________ff, out time, out ms);
        }

        public TimeSpan GetUpdateTime(int hhmm, int ssf, int ff)
        {
            int time;
            int ms;
            GetUpdateTime(hhmm, ssf, ff, out time, out ms);
            var hours = time / 10000;
            var minutes = (time % 10000) / 100;
            var seconds = time % 100;
            return new TimeSpan(0, hours, minutes, seconds, ms);
        }

        public TimeSpan GetUpdateTime(PbTick tick)
        {
            return GetUpdateTime(tick.Time_HHmm, tick.Time_____ssf__, tick.Time________ff);
        }
        #endregion
        

        public void SetLastPrice(PbTick tick, double price)
        {
            tick.LastPrice = PriceToTick(price);
        }
        public double GetLastPrice(PbTick tick)
        {
            return TickToPrice(tick.LastPrice);
        }

        public int PriceToTick(double price)
        {
            if (price >= 0)
                return (int)((price + TickSize / 2.0f) / TickSize);
            else
                return (int)((price - TickSize / 2.0f) / TickSize);
        }

        public double TickToPrice(int tick, double price = 0)
        {
            return Math.Round(price + tick * TickSize, 8);
        }

        // 全是浮点，表示是原始数
        public int DiffPrice(double price1, double price2)
        {
            if (price1 == price2)
                return 0;

            return PriceToTick(price1) - PriceToTick(price2);
        }

        // 全是整型，表示是已经处理过
        public int DiffPrice(int price1, int price2)
        {
            return price1 - price2;
        }

        /// <summary>
        /// 传入两个tick得到tick的差分
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public PbTick Diff(PbTick prev, PbTick current)
        {
            if (prev == null)
            {
                if (current.Config == null)
                    throw new Exception("快照的配置不能为空");
                // 是快照，直接返回
                return current;
            }

            PbTick tick = new PbTick();

            #region 配置数据
            // 当前数据为空或前后相同，表示
            if(current.Config == null || prev.Config.IsSame(current.Config))
            {
                tick.Config = null;
                // 可以继续下去
            }
            else
            {
                // 是新数据，返回快照
                _config = current.Config;
                TickSize = _config.GetTickSize();

                return current;
            }
            #endregion

            // 先取最关键的数据，因为前一条的config总会补成有效
            _config = prev.Config;
            TickSize = _config.GetTickSize();

            tick.LastPrice = current.LastPrice - prev.LastPrice;

            DepthTick from_last = null;
            DepthTick from_next = null;
            DepthTick to_last = null;
            DepthTick to_next = null;

            DepthTick last_last = null;
            DepthTick last_next = null;

            #region 买1到买N
            from_last = null;
            from_next = current.Depth1_3;
            to_last = null;
            to_next = tick.Depth1_3;

            last_last = null;
            last_next = prev.Depth1_3;

            while (true)
            {
                // 如果下一步没有数据，直接跳过
                if (from_next == null)
                    break;

                // 每节的循环
                if (from_next.BidSize1 == 0)
                    break;

                // 如果没有上一笔，这个地方就比较特殊
                if (from_last == null)
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        tick.Depth1_3 = to_next;
                    }
                    to_next.BidPrice1 = current.LastPrice - from_next.BidPrice1;
                }
                else
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        to_last.Next = to_next;
                    }
                    to_next.BidPrice1 = from_last.BidPrice3 - from_next.BidPrice1 - 1;
                }
                if (last_next == null)
                {
                    to_next.BidSize1 = from_next.BidSize1;
                    to_next.BidCount1 = from_next.BidCount1;
                }
                else
                {
                    to_next.BidSize1 = from_next.BidSize1 - last_next.BidSize1;
                    to_next.BidCount1 = from_next.BidCount1 - last_next.BidCount1;
                }


                if (from_next.BidSize2 == 0)
                    break;
                to_next.BidPrice2 = from_next.BidPrice1 - from_next.BidPrice2 - 1;
                if (last_next == null)
                {
                    to_next.BidSize2 = from_next.BidSize2;
                    to_next.BidCount2 = from_next.BidCount2;
                }
                else
                {
                    to_next.BidSize2 = from_next.BidSize2 - last_next.BidSize2;
                    to_next.BidCount2 = from_next.BidCount2 - last_next.BidCount2;
                }


                if (from_next.BidSize3 == 0)
                    break;

                to_next.BidPrice3 = from_next.BidPrice2 - from_next.BidPrice3 - 1;
                if (last_next == null)
                {
                    to_next.BidSize3 = from_next.BidSize3;
                    to_next.BidCount3 = from_next.BidCount3;
                }
                else
                {
                    to_next.BidSize3 = from_next.BidSize3 - last_next.BidSize3;
                    to_next.BidCount3 = from_next.BidCount3 - last_next.BidCount3;
                }

                // 移动到下一个数据块
                from_last = from_next;
                from_next = from_next.Next;

                to_last = to_next;
                to_next = to_next.Next;

                last_last = last_next;
                if (last_next != null)
                    last_next = last_next.Next;
            }
            #endregion

            #region 卖1到卖N
            from_last = null;
            from_next = current.Depth1_3;
            to_last = null;
            to_next = tick.Depth1_3;

            last_last = null;
            last_next = prev.Depth1_3;

            while (true)
            {
                // 如果下一步没有数据，直接跳过
                if (from_next == null)
                    break;

                // 每节的循环
                if (from_next.AskSize1 == 0)
                    break;

                // 如果没有上一笔，这个地方就比较特殊
                if (from_last == null)
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        tick.Depth1_3 = to_next;
                    }
                    to_next.AskPrice1 = from_next.AskPrice1 - current.LastPrice;
                }
                else
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        to_last.Next = to_next;
                    }
                    to_next.AskPrice1 = from_next.AskPrice1 - from_last.AskPrice3 - 1;
                }
                if (last_next == null)
                {
                    to_next.AskSize1 = from_next.AskSize1;
                    to_next.AskCount1 = from_next.AskCount1;
                }
                else
                {
                    to_next.AskSize1 = from_next.AskSize1 - last_next.AskSize1;
                    to_next.AskCount1 = from_next.AskCount1 - last_next.AskCount1;
                }

                if (from_next.AskSize2 == 0)
                    break;
                to_next.AskPrice2 = from_next.AskPrice2 - from_next.AskPrice1 - 1;
                if (last_next == null)
                {
                    to_next.AskSize2 = from_next.AskSize2;
                    to_next.AskCount2 = from_next.AskCount2;
                }
                else
                {
                    to_next.AskSize2 = from_next.AskSize2 - last_next.AskSize2;
                    to_next.AskCount2 = from_next.AskCount2 - last_next.AskCount2;
                }


                if (from_next.AskSize3 == 0)
                    break;
                to_next.AskPrice3 = from_next.AskPrice3 - from_next.AskPrice2 - 1;
                if (last_next == null)
                {
                    to_next.AskSize3 = from_next.AskSize3;
                    to_next.AskCount3 = from_next.AskCount3;
                }
                else
                {
                    to_next.AskSize3 = from_next.AskSize3 - last_next.AskSize3;
                    to_next.AskCount3 = from_next.AskCount3 - last_next.AskCount3;
                }

                // 移动到下一个数据块
                from_last = from_next;
                from_next = from_next.Next;

                to_last = to_next;
                to_next = to_next.Next;

                last_last = last_next;
                if (last_next != null)
                    last_next = last_next.Next;
            }
            #endregion

            #region 常用行情信息
            tick.Volume = current.Volume - prev.Volume;
            tick.OpenInterest = current.OpenInterest - prev.OpenInterest;
            tick.Turnover = current.Turnover - prev.Turnover;
            tick.AveragePrice = current.AveragePrice - prev.AveragePrice;
            tick.TradingDay = current.TradingDay - prev.TradingDay;
            tick.ActionDay = current.ActionDay - prev.ActionDay;

            tick.Time_HHmm = current.Time_HHmm - prev.Time_HHmm;
            tick.Time________ff = current.Time________ff - prev.Time________ff;
            // 这个地方有区别要减去一个差，将时间再缩小
            tick.Time_____ssf__ = current.Time_____ssf__ - prev.Time_____ssf__ - _config.Time_ssf_Diff;
            #endregion

            #region Bar数据
            // Bar数据要进行差分计算
            if (current.Bar != null || prev.Bar != null)
            {
                tick.Bar = new BarInfo();
                if (current.Bar == null)
                    current.Bar = new BarInfo();
                if (prev.Bar == null)
                    prev.Bar = new BarInfo();

                tick.Bar.Open = current.Bar.Open - prev.Bar.Open;
                tick.Bar.High = current.Bar.High - prev.Bar.High;
                tick.Bar.Low = current.Bar.Low - prev.Bar.Low;
                tick.Bar.Close = current.Bar.Close - prev.Bar.Close;
                tick.Bar.BarSize = current.Bar.BarSize - prev.Bar.BarSize;

                if (tick.Bar.IsZero)
                    tick.Bar = null;
            }
            #endregion

            #region 静态数据
            if (current.Static != null || prev.Static != null)
            {
                tick.Static = new StaticInfo();
                if (current.Static == null)
                    current.Static = new StaticInfo();
                if (prev.Static == null)
                    prev.Static = new StaticInfo();

                tick.Static.LowerLimitPrice = current.Static.LowerLimitPrice - prev.Static.LowerLimitPrice;
                tick.Static.UpperLimitPrice = current.Static.UpperLimitPrice - prev.Static.UpperLimitPrice;
                tick.Static.SettlementPrice = current.Static.SettlementPrice - prev.Static.SettlementPrice;

                if (!string.Equals(current.Static.Exchange,prev.Static.Exchange))
                    tick.Static.Exchange = current.Static.Exchange;

                if (!string.Equals(current.Static.Symbol, prev.Static.Symbol))
                    tick.Static.Symbol = current.Static.Symbol;
                

                if (tick.Static.IsZero)
                    tick.Static = null;
            }
            #endregion

            #region 除权除息数据
            // 除权除息数据本来就是稀疏矩阵，不需要做差分
            if (current.Split != null)
            {
                tick.Split = current.Split;

                if (tick.Split.IsZero)
                    tick.Split = null;
            }
            #endregion

            return tick;
        }

        public PbTick Restore(PbTick prev, PbTick diff)
        {
            if (prev == null)
            {
                if (diff.Config == null)
                    throw new Exception("快照的配置不能为空");
                // 记下配置，要用到
                _config = diff.Config;
                TickSize = _config.GetTickSize();
                // 是快照，直接返回
                return diff;
            }

            var tick = new PbTick();

            #region 配置数据
            if (diff.Config == null)
            {
                // 使用上条的配置
                tick.Config = prev.Config;
            }
            else
            {
                // 新配置
                _config = diff.Config;
                TickSize = _config.GetTickSize();
                // 是快照，直接返回
                return diff;
            }
            #endregion

            _config = tick.Config;
            TickSize = _config.GetTickSize();

            tick.LastPrice = prev.LastPrice + diff.LastPrice;

            DepthTick from_last = null;
            DepthTick from_next = null;
            DepthTick to_last = null;
            DepthTick to_next = null;

            DepthTick last_last = null;
            DepthTick last_next = null;

            #region 买1到买N
            from_last = null;
            from_next = diff.Depth1_3;
            to_last = null;
            to_next = tick.Depth1_3;

            last_last = null;
            last_next = prev.Depth1_3;

            while (true)
            {
                // 如果下一步没有数据，直接跳过
                if (from_next == null)
                    break;

                // 如果没有上一笔，这个地方就比较特殊
                if (from_last == null)
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        tick.Depth1_3 = to_next;
                    }
                    to_next.BidPrice1 = tick.LastPrice - from_next.BidPrice1;
                }
                else
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        to_last.Next = to_next;
                    }
                    to_next.BidPrice1 = to_last.BidPrice3 - from_next.BidPrice1 - 1;
                }

                to_next.BidPrice2 = to_next.BidPrice1 - from_next.BidPrice2 - 1;
                to_next.BidPrice3 = to_next.BidPrice2 - from_next.BidPrice3 - 1;

                if (last_next == null)
                {
                    to_next.BidSize1 = from_next.BidSize1;
                    to_next.BidSize2 = from_next.BidSize2;
                    to_next.BidSize3 = from_next.BidSize3;
                    to_next.BidCount1 = from_next.BidCount1;
                    to_next.BidCount2 = from_next.BidCount2;
                    to_next.BidCount3 = from_next.BidCount3;
                }
                else
                {
                    to_next.BidSize1 = from_next.BidSize1 + last_next.BidSize1;
                    to_next.BidSize2 = from_next.BidSize2 + last_next.BidSize2;
                    to_next.BidSize3 = from_next.BidSize3 + last_next.BidSize3;
                    to_next.BidCount1 = from_next.BidCount1 + last_next.BidCount1;
                    to_next.BidCount2 = from_next.BidCount2 + last_next.BidCount2;
                    to_next.BidCount3 = from_next.BidCount3 + last_next.BidCount3;
                }

                // 太复杂了，简化为发现Size=0就设Price等为0
                if (to_next.BidSize3 == 0)
                {
                    to_next.BidCount3 = 0;
                    to_next.BidPrice3 = 0;
                }
                if (to_next.BidSize2 == 0)
                {
                    to_next.BidCount2 = 0;
                    to_next.BidPrice2 = 0;
                }
                if (to_next.BidSize1 == 0)
                {
                    to_next.BidCount1 = 0;
                    to_next.BidPrice1 = 0;
                }

                // 移动到下一个数据块
                from_last = from_next;
                from_next = from_next.Next;

                to_last = to_next;
                to_next = to_next.Next;

                last_last = last_next;
                if (last_next != null)
                    last_next = last_next.Next;
            }
            #endregion

            #region 卖1到卖N
            from_last = null;
            from_next = diff.Depth1_3;
            to_last = null;
            to_next = tick.Depth1_3;

            last_last = null;
            last_next = prev.Depth1_3;

            while (true)
            {
                // 如果下一步没有数据，直接跳过
                if (from_next == null)
                    break;

                // 如果没有上一笔，这个地方就比较特殊
                if (from_last == null)
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        tick.Depth1_3 = to_next;
                    }
                    to_next.AskPrice1 = tick.LastPrice + from_next.AskPrice1;
                }
                else
                {
                    // 需要考察目标是否有数据
                    if (to_next == null)
                    {
                        to_next = new DepthTick();
                        to_last.Next = to_next;
                    }
                    to_next.AskPrice1 = to_last.AskPrice3 + from_next.AskPrice1 + 1;
                }

                to_next.AskPrice2 = to_next.AskPrice1 + from_next.AskPrice2 + 1;
                to_next.AskPrice3 = to_next.AskPrice2 + from_next.AskPrice3 + 1;

                if (last_next == null)
                {
                    to_next.AskSize1 = from_next.AskSize1;
                    to_next.AskSize2 = from_next.AskSize2;
                    to_next.AskSize3 = from_next.AskSize3;
                    to_next.AskCount1 = from_next.AskCount1;
                    to_next.AskCount2 = from_next.AskCount2;
                    to_next.AskCount3 = from_next.AskCount3;
                }
                else
                {
                    to_next.AskSize1 = from_next.AskSize1 + last_next.AskSize1;
                    to_next.AskSize2 = from_next.AskSize2 + last_next.AskSize2;
                    to_next.AskSize3 = from_next.AskSize3 + last_next.AskSize3;
                    to_next.AskCount1 = from_next.AskCount1 + last_next.AskCount1;
                    to_next.AskCount2 = from_next.AskCount2 + last_next.AskCount2;
                    to_next.AskCount3 = from_next.AskCount3 + last_next.AskCount3;
                }

                // 太复杂了，简化为发现Size=0就设Price等为0
                if (to_next.AskSize3 == 0)
                {
                    to_next.AskCount3 = 0;
                    to_next.AskPrice3 = 0;
                }
                if (to_next.AskSize2 == 0)
                {
                    to_next.AskCount2 = 0;
                    to_next.AskPrice2 = 0;
                }
                if (to_next.AskSize1 == 0)
                {
                    to_next.AskCount1 = 0;
                    to_next.AskPrice1 = 0;
                }


                // 移动到下一个数据块
                from_last = from_next;
                from_next = from_next.Next;

                to_last = to_next;
                to_next = to_next.Next;

                last_last = last_next;
                if (last_next != null)
                    last_next = last_next.Next;
            }
            #endregion

            #region 常用行情信息
            tick.Volume = prev.Volume + diff.Volume;
            tick.OpenInterest = prev.OpenInterest + diff.OpenInterest;
            tick.Turnover = prev.Turnover + diff.Turnover;
            tick.AveragePrice = prev.AveragePrice + diff.AveragePrice;
            tick.TradingDay = prev.TradingDay + diff.TradingDay;
            tick.ActionDay = prev.ActionDay + diff.ActionDay;

            tick.Time_HHmm = prev.Time_HHmm + diff.Time_HHmm;
            tick.Time________ff = prev.Time________ff + diff.Time________ff;
            // 还原时间
            tick.Time_____ssf__ = prev.Time_____ssf__ + diff.Time_____ssf__ + _config.Time_ssf_Diff;
            #endregion

            #region Bar数据
            if (prev.Bar != null || diff.Bar != null)
            {
                tick.Bar = new BarInfo();
                if (prev.Bar == null)
                    prev.Bar = new BarInfo();
                if (diff.Bar == null)
                    diff.Bar = new BarInfo();

                tick.Bar.Open = prev.Bar.Open + diff.Bar.Open;
                tick.Bar.High = prev.Bar.High + diff.Bar.High;
                tick.Bar.Low = prev.Bar.Low + diff.Bar.Low;
                tick.Bar.Close = prev.Bar.Close + diff.Bar.Close;
                tick.Bar.BarSize = prev.Bar.BarSize + diff.Bar.BarSize;
            }
            #endregion

            #region 静态数据
            if (prev.Static != null || diff.Static != null)
            {
                tick.Static = new StaticInfo();
                if (prev.Static == null)
                    prev.Static = new StaticInfo();
                if (diff.Static == null)
                    diff.Static = new StaticInfo();

                tick.Static.LowerLimitPrice = prev.Static.LowerLimitPrice + diff.Static.LowerLimitPrice;
                tick.Static.UpperLimitPrice = prev.Static.UpperLimitPrice + diff.Static.UpperLimitPrice;
                tick.Static.SettlementPrice = prev.Static.SettlementPrice + diff.Static.SettlementPrice;

                tick.Static.Symbol = string.IsNullOrWhiteSpace(diff.Static.Symbol) ? prev.Static.Symbol : diff.Static.Symbol;
                tick.Static.Exchange = string.IsNullOrWhiteSpace(diff.Static.Exchange) ? prev.Static.Exchange : diff.Static.Exchange;
            }
            #endregion

            #region 除权除息数据
            // 没有做过差分，所以直接返回
            if (diff.Split != null)
            {
                tick.Split = diff.Split;
            }
            #endregion

            return tick;
        }

        public List<PbTick> Restore(IEnumerable<PbTick> list)
        {
            if (list == null)
                return null;

            List<PbTick> _list = new List<PbTick>();

            PbTick last = null;
            foreach (var item in list)
            {
                last = Restore(last, item);
                _list.Add(last);
            }
            return _list;
        }

        public List<PbTick> Diff(IEnumerable<PbTick> list)
        {
            if (list == null)
                return null;

            List<PbTick> _list = new List<PbTick>();

            PbTick last = null;
            foreach (var item in list)
            {
                PbTick diff = Diff(last, item);
                last = item;
                _list.Add(diff);
            }
            return _list;
        }

        public List<PbTickView> Data2View(IEnumerable<PbTick> list, bool flat)
        {
            if (list == null)
                return null;

            Int2DoubleConverter converter = new Int2DoubleConverter(flat);
            List<PbTickView> tempList = new List<PbTickView>();

            foreach (var l in list)
            {
                tempList.Add(converter.Int2Double(l));
            }
            return tempList;
        }

        public List<PbTick> View2Data(IEnumerable<PbTickView> list, bool flat)
        {
            if (list == null)
                return null;

            Double2IntConverter converter = new Double2IntConverter(flat);
            List<PbTick> tempList = new List<PbTick>();

            foreach (var l in list)
            {
                tempList.Add(converter.Double2Int(l));
            }
            return tempList;
        }
    }
}
