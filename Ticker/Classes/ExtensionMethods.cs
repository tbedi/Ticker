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
    }
}