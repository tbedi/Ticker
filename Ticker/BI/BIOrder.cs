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
        public static double TotalCount { get; private set; }
        public List<OrderDTO> GetQuantityOrderCat()
        {
            List<OrderDTO> lsod = new List<OrderDTO>();
            try
            {
                //List<OrderDTO>
                lsod = order.GetQuantityOrderedCategory();
                double _TotalCount = 0;
                foreach (var item in lsod)
                {
                    _TotalCount = _TotalCount + item.QtyOrdered;
                }
                foreach (var items in lsod)
                {
                    items.QtyOrdered = Math.Round(((items.QtyOrdered / _TotalCount) * 100), 2);
                }
                BIOrder.TotalCount = _TotalCount;
              // object[] ls = lsod.ToPieChartSeries();
            }
            catch (Exception)
            {
            }
            return lsod;
        }

        public List<RegularOrderDTO> GetRegularOrderQuantity()
        {
            List<RegularOrderDTO> lsod = new List<RegularOrderDTO>();
            try
            {
                //List<OrderDTO>
                lsod = order.GetRegularQuantityOrdred();
                double _TotalCount = 0;
                foreach (var item in lsod)
                {
                    _TotalCount = _TotalCount + item.NoofRegularOrders;
                }
                foreach (var items in lsod)
                {
                    items.NoofRegularOrders = Math.Round(((items.NoofRegularOrders / _TotalCount) * 100), 2);
                }
                BIOrder.TotalCount = _TotalCount;
                // object[] ls = lsod.ToPieChartSeries();
            }
            catch (Exception)
            {
            }
            return lsod;
        }
        public List<PartOrderDTO> GetPartOrderQuantity()
        {
            List<PartOrderDTO> lsod = new List<PartOrderDTO>();
            try
            {
                //List<OrderDTO>
                lsod = order.GetPartQuantityOrdered();
                double _TotalCount = 0;
                if (lsod.Count>0)
                {
                    foreach (var item in lsod)
                    {
                        _TotalCount = _TotalCount + item.NoofPartOrders;
                    }
                    foreach (var items in lsod)
                    {
                        items.NoofPartOrders = Math.Round(((items.NoofPartOrders / _TotalCount) * 100), 2);
                    }
                    BIOrder.TotalCount = _TotalCount;
                }
              
                // object[] ls = lsod.ToPieChartSeries();
            }
            catch (Exception)
            {
            }
            return lsod;
        
        }


        public double GetTotalOrder()
        {
            return TotalCount;
        }
    }
}