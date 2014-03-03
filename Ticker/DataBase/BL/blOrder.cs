using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.DataBase.Command;
using Ticker.Charts;
using Ticker.Views;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;

namespace Ticker.DataBase.BL
{
    public  class blOrder
    {
      private static cmdClass order = new cmdClass();
        
       

        public  List<OrderDTO> lsQuantityOrderCategory = order.GetQuantityOrderedCategory();

        public  List<RegularOrderDTO> lsRegularOrder = order.GetRegularQuantityOrdred();

        public List<PartOrderDTO> lsPartOrder = order.GetPartQuantityOrdered();

        public List<TopQuantityOrdered> lstopQuantityorder = order.GetTop5SkuQuantityOrder();

        public List<TopPartnerDTO> lstopPartner = order.GetTop5ParnerOrder();

        public List<double> lsshipped = order.GetShipped();

        public int HoldOrder = order.GetNoOfHoldOrders();

        public blOrder()
        {
        }

        public List<OrderDTO> GetQuantityOrderCat(List<OrderDTO> lsQuantityOrderCat)
        {
            List<OrderDTO> lsQuantityOrderCatTemp = new List<OrderDTO>();
            try
            {
                lsQuantityOrderCatTemp = lsQuantityOrderCat;

                double _TotalCount = 0;
                foreach (var item in lsQuantityOrderCatTemp)
                {
                    _TotalCount = _TotalCount + item.QtyOrdered;
                }
                foreach (var items in lsQuantityOrderCatTemp)
                {
                    items.QtyOrdered = Math.Round(((items.QtyOrdered / _TotalCount) * 100), 2);
                }
            }
            catch (Exception)
            {
            }
            return lsQuantityOrderCatTemp;
        }

        public List<RegularOrderDTO> GetRegularOrderQuantity(List<RegularOrderDTO> lsRegularOrder)
        {
            List<RegularOrderDTO> lsRegularOrderTemp = new List<RegularOrderDTO>();
            try
            {
                lsRegularOrderTemp = lsRegularOrder;
                if (lsRegularOrderTemp.Count > 0)
                {
                    double _TotalCount = 0;
                    foreach (var item in lsRegularOrderTemp)
                    {
                        _TotalCount = _TotalCount + item.NoofRegularOrders;
                    }
                    foreach (var items in lsRegularOrderTemp)
                    {
                        items.NoofRegularOrders = Math.Round(((items.NoofRegularOrders / _TotalCount) * 100), 2);
                    }
                }
            }
            catch (Exception)
            {
            }
            return lsRegularOrderTemp;
        }
        public List<PartOrderDTO> GetPartOrderQuantity(List<PartOrderDTO> lsPartOrder)
        {
            List<PartOrderDTO> lsPartOrderTemp = new List<PartOrderDTO>();
            try
            {
                lsPartOrderTemp = lsPartOrder;
                double _TotalCount = 0;
                if (lsPartOrderTemp.Count > 0)
                {
                    foreach (var item in lsPartOrderTemp)
                    {
                        _TotalCount = _TotalCount + item.NoofPartsOrders;
                    }
                    foreach (var items in lsPartOrderTemp)
                    {
                        items.NoofPartsOrders = Math.Round(((items.NoofPartsOrders / _TotalCount) * 100), 2);
                    }
                }
              
            }
            catch (Exception)
            {
            }
            return lsPartOrderTemp;
        
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

        public double GetTotalOrder(List<OrderDTO> lsQuantityOrderCategory)
        {
            double _TotalCount = 0;
            foreach (var item in lsQuantityOrderCategory)
            {
                _TotalCount = _TotalCount + item.QtyOrdered;
            }
            return _TotalCount;
        }

        public List<TopQuantityOrdered> GetTop5QuantityOrder(List<TopQuantityOrdered> lstopQuantityorder)
        {
            return lstopQuantityorder;
        }

        public List<TopPartnerDTO> GetTop5Partner(List<TopPartnerDTO> lstopPartner)
        {
            return lstopPartner;
        }

        public string WebReasponce( String URL)
        {
            string _return = "0";
            try
            {
                // Create a new WebClient instance.
                WebClient myWebClient = new WebClient();
                // Download the Web resource and save it into a data buffer.
                byte[] myDataBuffer = myWebClient.DownloadData(URL);
                // Display the downloaded data.
                _return  = Encoding.ASCII.GetString(myDataBuffer);
                myWebClient.Dispose();
            }
            catch (Exception)
            {
            }
            return _return;
        }
    }
}