using System;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace stocktrader.Services
{
    public class TradingService : IDisposable
    {
        #region <|| PROPERTIES ||>
        private AlpacaTradingClient TradingClient { get; set; }
        private AlpacaDataClient DataClient { get; set; }

        #endregion <|| PROPERTIES ||>

        #region <|| CONSTRUCTORS ||>
        public TradingService(string key, string value)
        {
            TradingClient = Alpaca.Markets.Environments.Paper.GetAlpacaTradingClient(new SecretKey(key, value));
            DataClient = Alpaca.Markets.Environments.Paper.GetAlpacaDataClient(new SecretKey(key, value));
        }

        public void Dispose()
        {
            TradingClient?.Dispose();
            DataClient?.Dispose();
        }

        #endregion <|| CONSTRUCTORS ||>

        #region <|| PUBLIC METHODS ||>
        public async Task<bool> IsMarketOpen()
        {
            var clock = await TradingClient.GetClockAsync();
            return clock.IsOpen;
        }
        public async Task<DateTime> GetNextMarketOpen()
        {
            var clock = await TradingClient.GetClockAsync();
            return clock.NextOpen;
        }
        public async Task<DateTime> GetNextMarketClose()
        {
            var clock = await TradingClient.GetClockAsync();
            return clock.NextClose;
        }
        #endregion <|| PUBLIC METHODS ||>

        #region <|| PRIVATE METHODS ||>


        #endregion <|| PRIVATE METHODS ||>
    }
}
