using ProtoBuf;

namespace QuantBox.Data.Serializer.V2
{
    /// <summary>
    /// 配置信息，最关键的地方
    /// 如果为空表示差分数据，不为空表示快照数据
    /// </summary>
    [ProtoContract]
    public class ConfigInfo
    {
        /// <summary>
        /// 格式版本
        /// </summary>
        [ProtoMember(1)]
        public int Version;
        /// <summary>
        /// 实际值要先进行处理
        /// </summary>
        [ProtoMember(2)]
        public int TickSize;
        /// <summary>
        /// TickSize乘数，实际值*TickSizeMultiplier
        /// </summary>
        [ProtoMember(3)]
        public double TickSizeMultiplier;
        /// <summary>
        /// 结算价乘数，实际值*SettlementPriceMultiplier/TickSize
        /// </summary>
        [ProtoMember(4)]
        public int SettlementPriceMultiplier;
        /// <summary>
        /// 均价乘数，实际值*AveragePriceMultiplier/TickSize
        /// </summary>
        [ProtoMember(5)]
        public int AveragePriceMultiplier;
        /// <summary>
        /// 合约乘数
        /// </summary>
        [ProtoMember(6)]
        public double ContractMultiplier;
        /// <summary>
        /// ssf默认时间差，股指是500ms，Time_____ssf__会算出大量的5，默认减去此数还原成0
        /// </summary>
        [ProtoMember(7)]
        public int Time_ssf_Diff;
        /// <summary>
        /// 市场深度，比如说只有一档行情时，由于价格变动时用10,-10一类的表示太占，所这个来截断成10,0
        /// </summary>
        [ProtoMember(8)]
        public int MarketDepth;
        [ProtoMember(9)]
        public int MarketType;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(10)]
        public int Volume_Total_Or_Increment;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(11)]
        public int Turnover_Total_Or_Increment;


        public bool IsZero
        {
            get
            {
                return Version == 0
                       && TickSize == 0
                       && TickSizeMultiplier == 0
                       && SettlementPriceMultiplier == 0
                       && AveragePriceMultiplier == 0
                       && ContractMultiplier == 0
                       && Time_ssf_Diff == 0
                       && MarketDepth == 0
                       && MarketType == 0
                       && Volume_Total_Or_Increment == 0
                       && Turnover_Total_Or_Increment == 0;
            }
        }

        public bool IsSame(ConfigInfo config)
        {
            return Version == config.Version
                   && TickSize == config.TickSize
                   && TickSizeMultiplier == config.TickSizeMultiplier
                   && SettlementPriceMultiplier == config.SettlementPriceMultiplier
                   && AveragePriceMultiplier == config.AveragePriceMultiplier
                   && ContractMultiplier == config.ContractMultiplier
                   && Time_ssf_Diff == config.Time_ssf_Diff
                   && MarketDepth == config.MarketDepth
                   && MarketType == config.MarketType
                   && Volume_Total_Or_Increment == config.Volume_Total_Or_Increment
                   && Turnover_Total_Or_Increment == config.Turnover_Total_Or_Increment;
            ;
        }

        public void SetTickSize(double val)
        {
            TickSize = (int)(TickSizeMultiplier * val);
        }

        public double GetTickSize()
        {
            return TickSize / TickSizeMultiplier;
        }

        public double TurnoverMultiplier
        {
            get {
                return TickSize * ContractMultiplier / TickSizeMultiplier;
            }
        }

        public ConfigInfo Default()
        {
            Version = 2;
            TickSize = 1;
            TickSizeMultiplier = 10000.0;
            SettlementPriceMultiplier = 100;
            AveragePriceMultiplier = 100;
            ContractMultiplier = 1;
            Time_ssf_Diff = 0;
            MarketDepth = 0;
            MarketType = 2;
            Volume_Total_Or_Increment = 0;
            Turnover_Total_Or_Increment = 0;

            return this;
        }
    }
}