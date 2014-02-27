﻿using DotNet.Highcharts;
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

       public BI.BIOrder bOrder = new BI.BIOrder();

       protected void Page_Load(object sender, EventArgs e)
       {
           Call();
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
                            Call();
                        }));
                    thAjax.IsBackground = true;
                    thAjax.Start();
                }
            }
            catch (Exception)
            {
                thAjax = new Thread(new ThreadStart(() =>
                          {
                              Call();
                             
                          }));
                thAjax.IsBackground = true;
                thAjax.Start();
            }
        }

        private void Call()
        {
            ltrChart.Text = cDonut.OrderCanceledDonut().ToHtmlString();

            //ltrOrderhold.Text = cDonut.OrderHoldDonut().ToHtmlString();
            lblNewOrderNH.Text = (Convert.ToInt32(bOrder.GetTotalOrder())).ToString();

<<<<<<< HEAD
            ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered().ToHtmlString();
            ltrStackedColumnTop5Partner.Text = cStackedBar.GetTop_5_Partner_By_Ordered().ToHtmlString();
=======
            ltrStackedColumn.Text = cStackedBar.GetStackedBar().ToHtmlString();

            ltrRegularOrder.Text = cDonut.RegularOrder().ToHtmlString();
            litPartOrderQuantity.Text = cDonut.PartOrderQuantity().ToHtmlString();

>>>>>>> 5a04158fae527961faf3a0d0e6b9d0aa1b436c10
        }
    }
}