using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase.Command;

namespace Ticker.DataBase.BL
{
    public class blTicker
    {
        //Create object of cmdticker.
        private static cmdTicker _ticker = new cmdTicker();

        //Assign GetNewOrder to lsneworder List.
        public List<int> lsneworder = _ticker.GetNewOrder();

        //Assign GetNYWHShipped to lsNYWHShipped List.
        public List<int> lsNYWHShipped = _ticker.GetNYWHShipped();

        //Assign GetNYWTShipped to lsSYSShipped.
        public List<int> lsSYSShipped = _ticker.GetNYWTShipped();

        //Assign GetNYWHProccessing to lsNYWHProccessing.
        public List<int> lsNYWHProccessing = _ticker.GetNYWHProccessing();

        //Assign GetNYWTProccessing to lsSYSProccessing.
        public List<int> lsSYSProccessing = _ticker.GetNYWTProccessing();

        //Return NewOrder.
        public List<int> GetNewOrder()
        {
            return lsneworder;
        }

        //Return NYWHShipped.
        public List<int> GetNYWHShippedTicker()
        {
            return lsNYWHShipped;
        }

        //Return SYSShipped.
        public List<int> GetSYSShippedTicker()
        {
            return lsSYSShipped;
        }

        //Return NYWHProcessing.
        public List<int> GetNYWHProcessingTicker()
        {
            return lsNYWHProccessing;
        }

        //Return SYSProcessing.
        public List<int> GetSYSProcessingTicker()
        {
            return lsSYSProccessing;
        }



    }
}