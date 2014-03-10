using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Charts;
using Ticker.DataBase.BL;

namespace Ticker.Forms.Pages
{
    public partial class frmDashboard : System.Web.UI.Page
    {
        public static Thread thAjax;

        blTicker _ticker;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
               Call();
        }


        protected void tmrAjaxOrderOnCold_Tick(object sender, EventArgs e)
        {
            Call();
        }

        /// <summary>
        /// This Method is for Show All Values on The HighChart.
        /// </summary>
        private void Call()
        {
            //CREATE NEW Object calls database..
            cGlobal.Border = new blOrder();

            _ticker = new blTicker();

           // FillInternal_Ticker();
            if(cGlobal.Border.lstopPartnerByOrder.Count>0)
            ltrTOPPartnerByOrder.Text = cStackedBar.GetTop_5_Partner_By_OrderCount(cGlobal.Border.lstopPartnerByOrder).ToHtmlString();

            //if (cGlobal.Border.lstopQuantityorder.Count > 0)
            //    ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered(cGlobal.Border.lstopQuantityorder).ToHtmlString();

            if (cGlobal.Border.lstopPartner.Count > 0)
                ltrStackedColumnTop5Partner.Text = cStackedBar.GetTop_5_Partner_By_Sales(cGlobal.Border.lstopPartner).ToHtmlString();

            //lblHoldOrder.Text = cGlobal.Border.HoldOrder.ToString();
            //int ShippingInt = 0;
            //string Ship= Math.Round( cGlobal.Border.GetShippedpercentage(cGlobal.Border.lsshipped),0).ToString();
            //int.TryParse(Ship, out ShippingInt);
            //lblship.Text = ShippingInt.ToString() + "%";
            //if (cGlobal.Border.lsQuantityOrderCategory.Count > 0)
            //{
            //    lblNewOrderNH.Text = (Convert.ToInt32(cGlobal.Border.GetTotalOrder(cGlobal.Border.lsQuantityOrderCategory))).ToString();
            //    ltrChart.Text = cDonut.OrderCategory(cGlobal.Border.lsQuantityOrderCategory).ToHtmlString();
               
            //}
            //else
            //{
            //    lblNewOrderNH.Text = "No Data";
            //}
        }

        /// <summary>
        /// This Method is for Show Ticker Value on Guage.
        /// </summary>
        //private void FillInternal_Ticker()
        //{
        //    try
        //    {
        //        //string newShipment = "http://internal.kraususa.net/result.php?type=new";

        //        List<int> lsneworder=_ticker.GetNewOrder();
        //        Literal1.Text = cGuage.GetNewShipmentGuage(Convert.ToInt32(lsneworder[0].ToString())).ToHtmlString();

        //        List<int> lSYSProcess = _ticker.GetSYSProcessingTicker();
        //        //String SYSInProcess = "http://internal.kraususa.net/result.php?type=processed_nywt";
        //        ltrInProcessSOS.Text = cGuage.GetGreenSYS(Convert.ToInt32(lSYSProcess[0].ToString())).ToHtmlString();

                
        //        //String SYSShipped = "http://internal.kraususa.net/result.php?type=shipped_nywt";
        //        ltrShippedSYS.Text = cGuage.GetPurplSYS(Convert.ToInt32(_ticker.GetSYSShippedTicker()[0].ToString())).ToHtmlString();

        //        //String PWInProcess = "http://internal.kraususa.net/result.php?type=processed";

        //        ltrInprocessNyWH.Text = cGuage.GetGreenWT((Convert.ToInt32(_ticker.GetNYWHProcessingTicker()[0].ToString()))).ToHtmlString();
        //        //String PWShipped = "http://internal.kraususa.net/result.php?type=shipped_nywh";
        //        ltrShippedNYWH.Text = cGuage.GetPurplWT((Convert.ToInt32(_ticker.GetNYWHShippedTicker()[0].ToString()))).ToHtmlString();

        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        protected void Timer1_Tick(object sender, EventArgs e)
        {
         //   DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();

         //   //  lblNewOrderNH.Text = (Convert.ToInt32(cGlobal.Border.GetTotalOrder(cGlobal.Border.lsQuantityOrderCategory))).ToString();

         //   // ltrChart.Text = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();

         //   String Script = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();
         //   String S1 = Script.Replace("$(document).ready(function() ", "function mainDonut()");
         //   String S2 = S1.Replace("});" + Environment.NewLine + "</script>", "} " + Environment.NewLine + "</script>");
         //   ltrChart.Text = S2;
         //   ScriptManager.RegisterStartupScript(Timer1, Timer1.GetType(), "scriptname", "mainDonut();", true);
         //   //Page.ClientScript.RegisterStartupScript(this.GetType(), "mainDonut", "mainDonut();", true);
         //  // UpdatePanel1.Update();  
         ////   ScriptManager.RegisterStartupScript(this, Page.GetType(), "mainDonuts", "mainDonut();", true);
         ////   UpdatePanel1.Update();  
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
           // String Script = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();
           // String S1 = Script.Replace("$(document).ready(function() ", "function mainDonut()");
           // String S2 = S1.Replace("});" + Environment.NewLine + "</script>", "} " + Environment.NewLine + "</script>");
           // ltrChart.Text = S2;
           //// ScriptManager.RegisterStartupScript(this, Page.GetType(), "mainDonut", "mainDonut()", true);
           // //Page.ClientScript.RegisterStartupScript(this.GetType(), "mainDonut", "mainDonut();", true);
           
           // UpdatePanel1.Update();
        }



    }
}