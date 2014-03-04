﻿using DotNet.Highcharts;
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

        blTicker _ticker = new blTicker();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
               Call();

        }


        protected void tmrAjaxOrderOnCold_Tick(object sender, EventArgs e)
        {
            Call();
        }

        private void Call()
        {
            //CREATE NEW Object calls database..
            cGlobal.Border = new blOrder();

            FillInternal_Ticker();


            if (cGlobal.Border.lstopQuantityorder.Count > 0)
                ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered(cGlobal.Border.lstopQuantityorder).ToHtmlString();

            if (cGlobal.Border.lstopPartner.Count > 0)
                ltrStackedColumnTop5Partner.Text = cStackedBar.GetTop_5_Partner_By_Ordered(cGlobal.Border.lstopPartner).ToHtmlString();

            Boolean _Rflag = false;
            foreach (var item in cGlobal.Border.lsRegularOrder)
            {
                if (item.NoofRegularOrders > 0)
                    _Rflag = true;
            }
            //if (_Rflag)
            //{
            //    ltrRegularOrder.Text = cDonut.RegularOrder(cGlobal.Border.lsRegularOrder).ToHtmlString();
            //    lblErrorRegular.Visible = false;
            //}
            //else
            //{
            //    lblErrorRegular.Visible = true;
            //    lblErrorRegular.Text = "Record Not Found.";
            //}

            Boolean _flag = false;
            foreach (var item in cGlobal.Border.lsPartOrder)
            {
                if (item.NoofPartsOrders > 0)
                    _flag = true;
            }
            if (_flag)
            {
                litPartOrderQuantity.Text = cDonut.PartOrderQuantity(cGlobal.Border.lsPartOrder).ToHtmlString();
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Record Not Found.";
            }

            lblHoldOrder.Text = cGlobal.Border.HoldOrder.ToString();
            int ShippingInt = 0;
            string Ship= Math.Round( cGlobal.Border.GetShippedpercentage(cGlobal.Border.lsshipped),0).ToString();
            int.TryParse(Ship, out ShippingInt);
            lblship.Text = ShippingInt.ToString() + "%";
            if (cGlobal.Border.lsQuantityOrderCategory.Count > 0)
            {
                lblNewOrderNH.Text = (Convert.ToInt32(cGlobal.Border.GetTotalOrder(cGlobal.Border.lsQuantityOrderCategory))).ToString();
                ltrChart.Text = cDonut.OrderCanceledDonut(cGlobal.Border.lsQuantityOrderCategory).ToHtmlString();
               
            }
            else
            {
                lblNewOrderNH.Text = "No Data";
            }
        }

        private void FillInternal_Ticker()
        {
            try
            {
                //string newShipment = "http://internal.kraususa.net/result.php?type=new";

                List<int> lsneworder=_ticker.GetNewOrder();
                Literal1.Text = cGuage.GetNewShipmentGuage(Convert.ToInt32(lsneworder[0].ToString())).ToHtmlString();

                List<int> lsNYWTHship = _ticker.GetNYWHShippedTicker();
                //String SYSInProcess = "http://internal.kraususa.net/result.php?type=processed_nywt";
                ltrInProcessSOS.Text = cGuage.GetGreenSYS(Convert.ToInt32(lsNYWTHship[0].ToString())).ToHtmlString();

                
                //String SYSShipped = "http://internal.kraususa.net/result.php?type=shipped_nywt";
                ltrShippedSYS.Text = cGuage.GetPurplSYS(Convert.ToInt32(_ticker.GetNYWTShippedTicker()[0].ToString())).ToHtmlString();

                //String PWInProcess = "http://internal.kraususa.net/result.php?type=processed";

                ltrInprocessNyWH.Text = cGuage.GetGreenWT((Convert.ToInt32(_ticker.GetNYWHProcessingTicker()[0].ToString()))).ToHtmlString();
                //String PWShipped = "http://internal.kraususa.net/result.php?type=shipped_nywh";
                ltrShippedNYWH.Text = cGuage.GetPurplWT((Convert.ToInt32(_ticker.GetNYWHShippedTicker()[0].ToString()))).ToHtmlString();

            }
            catch (Exception)
            {
            }
        }



    }
}