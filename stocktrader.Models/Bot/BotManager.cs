using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace stocktrader.Models.Bot
{
    public class BotManager
    {
        #region <|| PROPERTIES ||>
        private List<StockBot> Bots { get; set; }
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
