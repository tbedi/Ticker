using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.Views;

namespace Ticker.DataBase.BL
{
    public static class ExtensionMethods
    {
        public static object[] ToPieChartSeries(this List<OrderDTO> data)
        {
            var returnObject = new List<object>();

            foreach (var item in data)
            {
                returnObject.Add(new object[] { item.Category, item.QtyOrdered });
            }

            return returnObject.ToArray();
        }

        public static object[] ToPichartRegularOrder(this List<RegularOrderDTO> data)
        {
            var returnObject = new List<object>();

            foreach (var item in data)
            {
                returnObject.Add(new object[] { item.OrderType, item.NoofRegularOrders });
            }

            return returnObject.ToArray();
        }
        public static object[] TOPiChartPartOrder(this List<PartOrderDTO> data)
        {
            var returnObject = new List<object>();

            foreach (var item in data)
            {
                returnObject.Add(new object[] { item.OrderType, item.NoofPartsOrders });
            }

            return returnObject.ToArray();
        }

        public static String[] ToCatagorysListFromPartner(this List<TopPartnerDTO> Partner)
        {
            String[] returnObject = new String[Partner.Count()];

            for (int i = 0; i < Partner.Count(); i++)
            {
                returnObject[i] = Partner[i].Partner.ToString();
            }

            return returnObject;
        }

        public static String[] ToCatagorysListFromSKU(this List<TopQuantityOrdered> Quantity)
        {
            String[] returnObject = new String[Quantity.Count()];

            for (int i = 0; i < Quantity.Count(); i++)
            {
                returnObject[i] = Quantity[i].SKU.ToString();
            }

            return returnObject;
        }



        public static object[] ToTop5ParnerObject(this List<TopPartnerDTO> lsPartner)
        {
            object[] returnObject = new object[lsPartner.Count()];

            for (int i = 0; i < lsPartner.Count(); i++)
            {
                returnObject[i] = Convert.ToInt32(lsPartner[i].QtyOrdered);
            }

            return returnObject;
        }
        public static object[] ToTop5SKUObject(this List<TopQuantityOrdered> lsTopQuantityOrdered)
        {
            object[] returnObject = new object[lsTopQuantityOrdered.Count()];

            for (int i = 0; i < lsTopQuantityOrdered.Count(); i++)
            {
                returnObject[i] = Convert.ToInt32(lsTopQuantityOrdered[i].QtyOrdered);
            }

            return returnObject;
        }


        public static double ToTotalOrderCount( this List<OrderDTO> lsQuantityOrderCategory)
        {
            double _TotalCount = 0;
            foreach (var item in lsQuantityOrderCategory)
            {
                _TotalCount = _TotalCount + item.QtyOrdered;
            }
            return _TotalCount;
        }


        public static double ToShippedpercentage(this List<double> lsshipped)
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
        /// Remove 0 Fileds from order DTO
        /// </summary>
        /// <param name="lsOrederDto"></param>
        /// <returns></returns>
        public static List<OrderDTO> RemoveLessThenZero(this List<OrderDTO> lsOrederDto)
        {
            List<OrderDTO> _rerurn = new List<OrderDTO>();
            Double Total = lsOrederDto.ToTotalOrderCount();
            Int32 Limit = Convert.ToInt32(Total / 100);

            foreach (var item in lsOrederDto)
            {
                if (item.QtyOrdered >= Limit)
                {
                    OrderDTO order = (OrderDTO)item;
                    _rerurn.Add(order);
                }
            }
            return _rerurn;
        }
    }
}