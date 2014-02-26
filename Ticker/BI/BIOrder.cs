using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase.Command;
using Ticker.Classes;
using Ticker.Views;

namespace Ticker.BI
{
    public  class BIOrder
    {
        cmdClass order = new cmdClass();

        public List<OrderDTO> GetOrder()
        {
            List<OrderDTO> lsod = new List<OrderDTO>();
            try
            {
                //List<OrderDTO>
                lsod = order.GetCategoryOrder();
                double Toatal = 0;
                foreach (var item in lsod)
                {
                    Toatal = Toatal + item.QtyOrdered;
                }
                foreach (var items in lsod)
                {
                    items.QtyOrdered = Math.Round(((items.QtyOrdered / Toatal) * 100), 2);
                }
              // object[] ls = lsod.ToPieChartSeries();
            }
            catch (Exception)
            {
            }
            return lsod;
        }
    }
}