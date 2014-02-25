using DotNet.Highcharts;
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
            ltrChart.Text = cDonut.ExampleDonut().ToHtmlString();
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static String apply()
        {
            String name = @"[['Firefox', 44.2],['IE7', 26.6],['IE6', 20],['Chrome', 3.1],['Remain',10]]";
            return name;
        }


    }
  public  class nameValue
    {
        public int Value { get; set; }
        public String Name { get; set; }
    }

}