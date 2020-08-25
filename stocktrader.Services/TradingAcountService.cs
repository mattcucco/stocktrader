using Alpaca.Markets;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace stocktrader.Services
{
    /// <summary>
    /// Helper class for TradingService. 
    /// Explicitly handles account information from the trading client.
    /// </summary>
    class TradingAcountService
    {
        #region <|| PROPERTIES ||>
        private AlpacaTradingClient TradingClient { get; set; }
        private IAccount TradingAcount { get; set; }
        
        #endregion <|| PROPERTIES ||>

        #region <|| CONSTRUCTORS ||> 
        public TradingAcountService(AlpacaTradingClient client)
        {
            TradingClient = client;
        }
        public async Task Init(CancellationToken cancellationToken = default)
        {
            TradingAcount = await TradingClient.GetAccountAsync(cancellationToken);
        }
        #endregion <|| CONSTRUCTORS ||>

        #region <|| PUBLIC METHODS ||>

        public decimal GetAcountTradingPower()
        {
            if(TradingAcount != null)
            {
                return TradingAcount.BuyingPower;
            }
            else
            {
                return new decimal(0.00f);
            }
        }
        public decimal GetAcountEquity()
        {
            if (TradingAcount != null)
            {
                return TradingAcount.Equity;
            }
            else
            {
                return new decimal(0.00f);
            }
        }

        #endregion <|| PUBLIC METHODS ||>
    }
}
