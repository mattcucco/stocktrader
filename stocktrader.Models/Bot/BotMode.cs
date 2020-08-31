using System;
using System.Collections.Generic;
using System.Text;

namespace stocktrader.Models.Bot
{
    public class BotMode
    {
        public enum TradingMode
        {
            TEST,
            LIVE
        }

        public enum TradingStatus
        {
            IDLE,
            BUYING,
            SELLING
        }

        public enum BotStatus
        {
            NEW,
            ACTIVATING,
            ACTIVE,
            DEACTIVATING,
            DEACTIVE,
            REMOVED
        }
    }
}
