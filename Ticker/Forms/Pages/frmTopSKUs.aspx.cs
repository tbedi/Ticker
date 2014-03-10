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
    public partial class frmTopSKUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cGlobal.Border = new blOrder();
                 if (cGlobal.Border.lstopQuantityorder.Count > 0)
                ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered(cGlobal.Border.lstopQuantityorder).ToHtmlString();

            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (cGlobal.Border.lstopQuantityorder.Count > 0)
                ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered(cGlobal.Border.lstopQuantityorder).ToHtmlString();

        }
    }
}