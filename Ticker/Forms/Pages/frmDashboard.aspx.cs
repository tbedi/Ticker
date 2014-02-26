using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Classes;
namespace Ticker.Forms.Pages
{
    public partial class frmDashboard : System.Web.UI.Page
    {
        public static Thread thAjax;
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrChart.Text = cDonut.OrderCanceledDonut().ToHtmlString();
            ltrOrderhold.Text = cDonut.OrderHoldDonut().ToHtmlString();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void apply()
        {
           
        }

        protected void tmrAjax_Tick(object sender, EventArgs e)
        {
            
        }

        protected void tmrAjaxOrderOnCold_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!thAjax.IsAlive)
                {
                    thAjax = new Thread(new ThreadStart(() =>
                        {
                            ltrChart.Text = cDonut.OrderCanceledDonut().ToHtmlString();
                            ltrOrderhold.Text = cDonut.OrderHoldDonut().ToHtmlString();
                        }));
                    thAjax.IsBackground = true;
                    thAjax.Start();
                }
            }
            catch (Exception)
            {
                thAjax = new Thread(new ThreadStart(() =>
                          {
                              ltrChart.Text = cDonut.OrderCanceledDonut().ToHtmlString();
                              ltrOrderhold.Text = cDonut.OrderHoldDonut().ToHtmlString();
                          }));
                thAjax.IsBackground = true;
                thAjax.Start();
            }
        }
    }
}