using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticker.Classes
{
    public static class ExtensionMethods
    {
            public static object[] ToPieChartSeries(this string data)
            {
                var returnObject = new List<object>();

                //foreach (var item in data)
                //{
                //    returnObject.Add(new object[] { item.name, item.count });
                //}

                return returnObject.ToArray();
            }
    }
}