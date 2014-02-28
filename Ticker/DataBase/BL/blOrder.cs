using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase.Command;
using Ticker.Charts;
using Ticker.Views;

namespace Ticker.DataBase.BL
{
    public  class blOrder
    {
      private static cmdClass order = new cmdClass();
        
        public static double TotalCount { get; private set; }

        public  List<OrderDTO> lsQuantityOrderCategory = order.GetQuantityOrderedCategory();

        public  List<RegularOrderDTO> lsRegularOrder = order.GetRegularQuantityOrdred();

        public List<PartOrderDTO> lsPartOrder = order.GetPartQuantityOrdered();

        public List<TopQuantityOrdered> lstopQuantityorder = order.GetTop5SkuQuantityOrder();

        public List<TopPartnerDTO> lstopPartner = order.GetTop5ParnerOrder();



        public List<double> lsshipped = order.GetShipped();

        public int HoldOrder = order.GetNoOfHoldOrders();

        public blOrder()
        {
            TotalCount = 0;
        }

        public List<OrderDTO> GetQuantityOrderCat(List<OrderDTO> lsQuantityOrderCategory)
        {
            try
            {
                double _TotalCount = 0;
                foreach (var item in lsQuantityOrderCategory)
                {
                    _TotalCount = _TotalCount + item.QtyOrdered;
                }
                foreach (var items in lsQuantityOrderCategory)
                {
                    items.QtyOrdered = Math.Round(((items.QtyOrdered / _TotalCount) * 100), 2);
                }
                blOrder.TotalCount = _TotalCount;
            }
            catch (Exception)
            {
            }
            return lsQuantityOrderCategory;
        }

        public List<RegularOrderDTO> GetRegularOrderQuantity(List<RegularOrderDTO> lsRegularOrder)
        {
            try
            {
                if (lsRegularOrder.Count > 0)
                {
                    double _TotalCount = 0;
                    foreach (var item in lsRegularOrder)
                    {
                        _TotalCount = _TotalCount + item.NoofRegularOrders;
                    }
                    foreach (var items in lsRegularOrder)
                    {
                        items.NoofRegularOrders = Math.Round(((items.NoofRegularOrders / _TotalCount) * 100), 2);
                    }
                    blOrder.TotalCount = _TotalCount;
                }
            }
            catch (Exception)
            {
            }
            return lsRegularOrder;
        }
        public List<PartOrderDTO> GetPartOrderQuantity(List<PartOrderDTO> lsPartOrder)
        {
            try
            {
                double _TotalCount = 0;
                if (lsPartOrder.Count > 0)
                {
                    foreach (var item in lsPartOrder)
                    {
                        _TotalCount = _TotalCount + item.NoofPartsOrders;
                    }
                    foreach (var items in lsPartOrder)
                    {
                        items.NoofPartsOrders = Math.Round(((items.NoofPartsOrders / _TotalCount) * 100), 2);
                    }
                    blOrder.TotalCount = _TotalCount;
                }
              
            }
            catch (Exception)
            {
            }
            return lsPartOrder;
        
        }

        public double GetShippedpercentage(List<double> lsshipped)
        {
            double _TotalCount = 0;
            try
            {
                if (lsshipped.Count > 0)
                {
                    _TotalCount = (lsshipped[0] / lsshipped[1]) * 100;
                }
            }
            catch (Exception)
            {
            }
            return _TotalCount;
        }

        public int GetHold(int HoldOrder)
        {
            int hold = 0;
            try
            {
                hold = HoldOrder;
            }
            catch (Exception)
            {
            }
            return hold;
        }

        public double GetTotalOrder()
        {
            return TotalCount;
        }

        public List<TopQuantityOrdered> GetTop5QuantityOrder(List<TopQuantityOrdered> lstopQuantityorder)
        {
            return lstopQuantityorder;
        }

        public List<TopPartnerDTO> GetTop5Partner(List<TopPartnerDTO> lstopPartner)
        {
            return lstopPartner;
        }
    }
}