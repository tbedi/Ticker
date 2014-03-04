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

        public List<int> lsNYWTShipped = _ticker.GetNYWTShipped();

        public List<int> lsNYWHProccessing = _ticker.GetNYWHProccessing();

        public List<int> lsNYWTProccessing = _ticker.GetNYWTProccessing();

        public List<int> GetNewOrder()
        {
            return lsneworder;
        }

        public List<int> GetNYWHShippedTicker()
        {
            return lsNYWHShipped;
        }

        public List<int> GetNYWTShippedTicker()
        {
            return lsNYWTShipped;
        }

        public List<int> GetNYWHProcessingTicker()
        {
            return lsNYWHProccessing;
        }

        public List<int> GetNYWTProcessingTicker()
        {
            return lsNYWTProccessing;
        }



    }
}