using stocktrader.Models.Bot;
using stocktrader.Models.Stocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace stocktrader.Services
{
    public class BotManagerService
    {
        #region <|| PROPERTIES ||>
        private List<StockBot> Bots { get; set; }
        private Queue<Stock> OrderQueue { get; set; }
        private TradingService TradingService { get; set; }
        #endregion

        #region <|| CONSTRUCTORS ||>
        public BotManagerService(TradingService tradingService)
        {
            TradingService = tradingService;
        }
        public async Task Init()
        {
            Console.WriteLine("Initializing Bot Manager...");

            //Load Accounts


        }
        #endregion

        #region <|| PUBLIC METHODS ||>
        public async Task CreateBot()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteBot()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateBot()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<StockBot> GetBots()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
