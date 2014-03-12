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
        //Create Object of cmdclass.
      private static cmdClass order = new cmdClass();
      
        /// <summary>
        /// Assign GetQuantityOrderedCategory to List of OrderDTO lsQuantityOrderCategory
        /// </summary>
        public  List<OrderDTO> lsQuantityOrderCategory = order.GetQuantityOrderedCategory();

        /// <summary>
        /// Assign GetRegularQuantityOrdred to List of RegularDTO lsRegularOrder
        /// </summary>
        public  List<AmountOrderDTO> lsRegularOrder = order.GetAmountCategoryOrdred();

        /// <summary>
        /// Assign GetPartQuantityOrdered Method to list of PartorderDTO lsPartOrerDTO. 
        /// </summary>
        public List<PartOrderDTO> lsPartOrder = order.GetPartQuantityOrdered();

        /// <summary>
        /// Assign GetTop5SkuQuantityOrder Method to list of topQuantityOrdered lstopQuantityorder.
        /// </summary>
        public List<TopQuantityOrdered> lstopQuantityorder = order.GetTop5SkuQuantityOrder();

        /// <summary>
        /// Assign GetTop5ParnerOrder method to list of TopPartnerDTO lstopPartner.
        /// </summary>
        public List<TopPartnerDTO> lstopPartner = order.GetTop5ParnerSale();

        /// <summary>
        /// Assign GetTop5ParnerByOrder method to list of TopPartnerDTO lstopPartnerByOrder.
        /// </summary>
        public List<TopPartnerDTO> lstopPartnerByOrder = order.GetTop5ParnerByOrder();

        /// <summary>
        /// Assign GetShipped method to list of Double lsshipped.
        /// </summary>
        public List<double> lsshipped = order.GetShipped();

        /// <summary>
        /// Assign GetNoOfHoldOrders method to int HoldOrder.
        /// </summary>
        public int HoldOrder = order.GetNoOfHoldOrders();

        /// <summary>
        /// Blank Constructore.
        /// </summary>
        public blOrder()
        {
        }
        /// <summary>
        /// This is method is for GetQuantity Category list with calculation. 
        /// </summary>
        /// <param name="lsQuantityOrderCat">
        /// OrderDTO is pass as parameter.
        /// </param>
        /// <returns>
        /// Return List of OrderDTO lsQuantityOrderCatTemp.
        /// </returns>
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
        /// <summary>
        /// This Method is for get Redular order list with Caculation
        /// </summary>
        /// <param name="lsRegularOrder">
        /// Pass list of Regular order.
        /// </param>
        /// <returns>
        /// Return List of Regular Order.
        /// </returns>
        //public List<AmountOrderDTO> GetRegularOrderQuantity(List<AmountOrderDTO> lsRegularOrder)
        //{
        //    List<AmountOrderDTO> lsRegularOrderTemp = new List<AmountOrderDTO>();
        //    try
        //    {
        //        lsRegularOrderTemp = lsRegularOrder;
        //        if (lsRegularOrderTemp.Count > 0)
        //        {
        //            double _TotalCount = 0;
        //            foreach (var item in lsRegularOrderTemp)
        //            {
        //                _TotalCount = _TotalCount + item.NoofRegularOrders;
        //            }
        //            foreach (var items in lsRegularOrderTemp)
        //            {
        //                items.NoofRegularOrders = Math.Round(((items.NoofRegularOrders / _TotalCount) * 100), 2);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //    return lsRegularOrderTemp;
        //}

        /// <summary>
        /// This Method is for get Part Order List with Calculation.
        /// </summary>
        /// <param name="lsPartOrder">
        /// Pass list of PartorderDTO as parameter.
        /// </param>
        /// <returns></returns>
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
        /// <summary>
        /// Get Shipped Percentage No.
        /// </summary>
        /// <param name="lsshipped">
        /// pass list of shipped as parameter.
        /// </param>
        /// <returns>
        /// return double Value.
        /// </returns>
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

        /// <summary>
        /// Get Hold Order.
        /// </summary>
        /// <param name="HoldOrder"></param>
        /// <returns>
        /// Return Integer Value.
        /// </returns>
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

        /// <summary>
        /// Get Total order Category.
        /// </summary>
        /// <param name="lsQuantityOrderCategory">
        /// List of OrderDTO Pass as parameter.
        /// </param>
        /// <returns>
        /// Return List.
        /// </returns>
        public double GetTotalOrder(List<OrderDTO> lsQuantityOrderCategory)
        {
            double _TotalCount = 0;
            foreach (var item in lsQuantityOrderCategory)
            {
                _TotalCount = _TotalCount + item.QtyOrdered;
            }
            return _TotalCount;
        }

        /// <summary>
        /// Get top 5 Quantity Order.
        /// </summary>
        /// <param name="lstopQuantityorder"></param>
        /// <returns></returns>
        public List<TopQuantityOrdered> GetTop5QuantityOrder(List<TopQuantityOrdered> lstopQuantityorder)
        {
            return lstopQuantityorder;
        }

        /// <summary>
        /// Get Top 5 Partner Sales order.
        /// </summary>
        /// <param name="lstopPartner"></param>
        /// <returns></returns>
        public List<TopPartnerDTO> GetTop5Partner(List<TopPartnerDTO> lstopPartner)
        {
            return lstopPartner;
        }

        /// <summary>
        /// Get Top 5 Partner order.
        /// </summary>
        /// <param name="lstopPartner"></param>
        /// <returns></returns>
        public List<TopPartnerDTO> GetTop5PartnerByOrder(List<TopPartnerDTO> lstopPartner)
        {
            return lstopPartnerByOrder;
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