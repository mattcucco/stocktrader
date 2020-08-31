using System;
using System.Collections.Generic;
using System.Text;

namespace stocktrader.Models.Stocks
{
    public class Strategy
    {
        #region <|| PROPERTIES ||>

        #endregion <|| PROPERTIES ||>


        #region <|| PUBLIC METHODS ||>
        /// <summary>
        /// Determines what action to take for a given stock
        /// based on the current market data and the current trading strategy
        /// </summary>
        /// <param name="stock"></param>
        public StrategyAction PerformAction(Stock stock)
        {
            //Get Stock Information

            //If owned - should bot sell or hold

            //Else If not owned - should bot buy

            //Else do nothing
            throw new NotImplementedException();
        }
        #endregion <|| PUBLIC METHODS ||>
    }

    public enum StrategyAction
    {
        Idle = 0,
        Buy,
        Sell,
        Hold
    }
}
