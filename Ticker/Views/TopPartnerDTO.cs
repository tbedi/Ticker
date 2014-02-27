using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticker.Views
{
    public class TopPartnerDTO
    {
        public string PartnerID { get; set; }
        public string Partner { get; set; }
        public float QtyOrdered { get; set; }
    }
}