﻿using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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


    }
}