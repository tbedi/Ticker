using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Classes;

namespace Ticker.Forms.Pages
{
    public partial class frmStackedBar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrChart.Text = cStackedBar.GetStackedBar().ToHtmlString();
        }
    }
}