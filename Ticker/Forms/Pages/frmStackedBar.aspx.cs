using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Charts;
using Ticker.DataBase.BL;

namespace Ticker.Forms.Pages
{
    public partial class frmStackedBar : System.Web.UI.Page
    {
        public blOrder bOrder = new blOrder();

        protected void Page_Load(object sender, EventArgs e)
        {
          //  ltrChart.Text = cStackedBar.GetTop_5_SKU_By_Ordered(bOrder).ToHtmlString();
        }
    }
}