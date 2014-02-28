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
    }
}