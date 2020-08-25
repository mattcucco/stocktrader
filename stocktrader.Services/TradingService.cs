using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace stocktrader.Services
{
    public class TradingService : IDisposable
    {
        #region <|| PROPERTIES ||>
        private AlpacaTradingClient TradingClient { get; set; }
        private AlpacaDataClient DataClient { get; set; }
        private TradingAcountService AcountService { get; set; }

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

        public async Task Init(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
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
        public async Task DeleteOpenOrders()
        {
            var orders = await TradingClient.ListOrdersAsync(new ListOrdersRequest());
            foreach(var o in orders)
            {
                var res = await TradingClient.DeleteOrderAsync(o.OrderId);
            }
        }
        public async Task<TimeSpan> GetTimeUntilMarketClose()
        {
            return await GetNextMarketClose() - DateTime.UtcNow;
        }
        #endregion <|| PUBLIC METHODS ||>

        #region <|| PRIVATE METHODS ||>


        #endregion <|| PRIVATE METHODS ||>
    }
}
