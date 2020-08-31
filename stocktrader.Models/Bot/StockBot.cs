using stocktrader.Models.Stocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace stocktrader.Models.Bot
{
    public class StockBot
    {
        #region <|| PROPERTIES ||>
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public Guid BotID { get; set; }
        public decimal BuyingPower { get; set; }
        public Strategy TradingStrategy { get; set; }
        public List<string> WatchList { get; set; }
        #endregion <|| PROPERTIES ||>

        #region <|| CONSTRUCTORS ||>

        #endregion <|| CONSTRUCTORS ||>

        #region <|| PUBLIC METHODS ||>
        public async Task CheckMarket()
        {
            throw new NotImplementedException();
        }

        public async Task SubmitAction()
        {
            throw new NotImplementedException();
        }

        #endregion <|| PUBLIC METHODS ||>
    }
}
