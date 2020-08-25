using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alpaca.Markets;
using stocktrader.Models.Configuration;

namespace stocktrader.Services
{
    public class TradingService : IDisposable
    {
        #region <|| PROPERTIES ||>
        private AlpacaTradingClient TradingClient { get; set; }
        private AlpacaDataClient DataClient { get; set; }
        private TradingAccountService AccountService { get; set; }

        #endregion <|| PROPERTIES ||>

        #region <|| CONSTRUCTORS ||>
        public TradingService(ISecretRevealer revealer)
        {
            var secrets = revealer.GetAlpacaKeys();
            var key = new SecretKey(secrets.Key, secrets.Value);

            TradingClient = Alpaca.Markets.Environments.Paper.GetAlpacaTradingClient(key);
            DataClient = Alpaca.Markets.Environments.Paper.GetAlpacaDataClient(key);
            AccountService = new TradingAccountService(TradingClient);
        }

        public void Dispose()
        {
            TradingClient?.Dispose();
            DataClient?.Dispose();
        }

        public async Task Init(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Initializing Bot...");

            var marketStatus = await IsMarketOpen() ? "Open" : "Closed";
            var timeLeft = await GetTimeUntilMarketClose();
            var timeClose = await GetNextMarketClose();

            Console.WriteLine($"Market Status: {marketStatus}");
            Console.WriteLine($"Local Market Close: {timeClose:MM/dd/yyyy hh:mm tt}");
            Console.WriteLine($"UTC Market Close: {timeClose.ToUniversalTime():MM/dd/yyyy hh:mm tt}");
            Console.WriteLine($"Time Remaining: {timeLeft.Hours}h:{timeLeft.Minutes}m:{timeLeft.Seconds}s");

            await AccountService.Init(cancellationToken);

            Console.WriteLine("Bot Ready...");
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
            var nextClose = await GetNextMarketClose();
            return  nextClose.ToUniversalTime() - DateTime.UtcNow;
        }
        #endregion <|| PUBLIC METHODS ||>

        #region <|| PRIVATE METHODS ||>


        #endregion <|| PRIVATE METHODS ||>
    }
}
