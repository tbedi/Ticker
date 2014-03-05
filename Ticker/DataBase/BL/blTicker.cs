using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase.Command;

namespace Ticker.DataBase.BL
{
    public class blTicker
    {
        private static cmdTicker _ticker = new cmdTicker();

        public List<int> lsneworder = _ticker.GetNewOrder();

        public List<int> lsNYWHShipped = _ticker.GetNYWHShipped();

        public List<int> lsSYSShipped = _ticker.GetNYWTShipped();

        public List<int> lsNYWHProccessing = _ticker.GetNYWHProccessing();

        public List<int> lsSYSProccessing = _ticker.GetNYWTProccessing();

        public List<int> GetNewOrder()
        {
            return lsneworder;
        }

        public List<int> GetNYWHShippedTicker()
        {
            return lsNYWHShipped;
        }

        public List<int> GetSYSShippedTicker()
        {
            return lsSYSShipped;
        }

        public List<int> GetNYWHProcessingTicker()
        {
            return lsNYWHProccessing;
        }

        public List<int> GetSYSProcessingTicker()
        {
            return lsSYSProccessing;
        }



    }
}