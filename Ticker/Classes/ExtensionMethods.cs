using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticker.Views;

namespace Ticker.Classes
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

        public static object[] RegularOrder(this List<RegularOrderDTO> data)
        {
            var returnObject = new List<object>();

            foreach (var item in data)
            {
                returnObject.Add(new object[] { item.OrderType, item.NoofRegularOrders });
            }

            return returnObject.ToArray();
        }
        public static object[] PartOrder(this List<PartOrderDTO> data)
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
            String[] returnObject = new String[Partner.Count() - 1];

            for (int i = 0; i < Partner.Count()-1; i++)
            {
                returnObject[i] = Partner[i].Partner.ToString();
            }

            return returnObject;
        }

        public static String[] ToCatagorysListFromSKU(this List<TopQuantityOrdered> Quantity)
        {
            String[] returnObject = new String[Quantity.Count() - 1];

            for (int i = 0; i < Quantity.Count()-1; i++)
            {
                returnObject[i] = Quantity[i].SKU.ToString();
            }

            return returnObject;
        }



        public static object[] ToTop5ParnerObject(this List<TopPartnerDTO> lsPartner)
        {
            object[] returnObject = new object[lsPartner.Count() - 1];

            for (int i = 0; i < lsPartner.Count()-1; i++)
            {
                returnObject[i] = Convert.ToInt32(lsPartner[i].QtyOrdered);
            }

            return returnObject;
        }
        public static object[] ToTop5SKUObject(this List<TopQuantityOrdered> lsTopQuantityOrdered)
        {
            object[] returnObject = new object[lsTopQuantityOrdered.Count() - 1];

            for (int i = 0; i < lsTopQuantityOrdered.Count()-1; i++)
            {
                returnObject[i] = Convert.ToInt32(lsTopQuantityOrdered[i].QtyOrdered);
            }

            return returnObject;
        }
    }
}