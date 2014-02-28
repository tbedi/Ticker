using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Charts;

namespace Ticker.Forms.Pages
{
    public partial class frmGuage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrChart.Text = cGuage.GetGuage().ToHtmlString();
           // ltrChart.Text = cDonut.ExampleDonut().ToHtmlString();
        }
    }
}