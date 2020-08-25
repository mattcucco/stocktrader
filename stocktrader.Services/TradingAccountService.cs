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
    class TradingAccountService
    {
        #region <|| PROPERTIES ||>
        private AlpacaTradingClient TradingClient { get; set; }
        private IAccount TradingAccount { get; set; }
        
        #endregion <|| PROPERTIES ||>

        #region <|| CONSTRUCTORS ||> 
        public TradingAccountService(AlpacaTradingClient client)
        {
            TradingClient = client;
        }
        public async Task Init(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Loading Account...");
            TradingAccount = await TradingClient.GetAccountAsync(cancellationToken);
            Console.WriteLine($"Acount Status: {TradingAccount.Status}");
            Console.WriteLine($"Buying Power: {GetAcountTradingPower()}");
            Console.WriteLine($"Equity: {GetAcountEquity()}");
        }
        #endregion <|| CONSTRUCTORS ||>

        #region <|| PUBLIC METHODS ||>

        public decimal GetAcountTradingPower()
        {
            if(TradingAccount != null)
            {
                return TradingAccount.BuyingPower;
            }
            else
            {
                return new decimal(0.00f);
            }
        }
        public decimal GetAcountEquity()
        {
            if (TradingAccount != null)
            {
                return TradingAccount.Equity;
            }
            else
            {
                return new decimal(0.00f);
            }
        }

        #endregion <|| PUBLIC METHODS ||>
    }
}
