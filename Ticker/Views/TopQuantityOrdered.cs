using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticker.Views
{
    public class TopQuantityOrdered
    {
        public string  ProductID { get; set; }
        public string  SKU { get; set; }
        public float QtyOrdered { get; set; }
    }
}