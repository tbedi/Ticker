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

        public blOrder bOrder = new blOrder();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            Call();
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
            FillInternal_Ticker();

            if (bOrder.lsQuantityOrderCategory.Count > 0)
            {
                ltrChart.Text = cDonut.OrderCanceledDonut(bOrder.lsQuantityOrderCategory).ToHtmlString();
                lblNewOrderNH.Text = (Convert.ToInt32(bOrder.GetTotalOrder())).ToString();
            }
            else
            {
                lblNewOrderNH.Text = "No Data";
            }
            if (bOrder.lsQuantityOrderCategory.Count > 0)
                ltrStackedColumnTop5SKU.Text = cStackedBar.GetTop_5_SKU_By_Ordered(bOrder.lstopQuantityorder).ToHtmlString();

            if (bOrder.lstopPartner.Count > 0)
                ltrStackedColumnTop5Partner.Text = cStackedBar.GetTop_5_Partner_By_Ordered(bOrder.lstopPartner).ToHtmlString();

            Boolean _Rflag = false;
            foreach (var item in bOrder.lsRegularOrder)
            {
                if (item.NoofRegularOrders > 0)
                    _Rflag = true;
            }
            if (_Rflag)
            {
                ltrRegularOrder.Text = cDonut.RegularOrder(bOrder.lsRegularOrder).ToHtmlString();
                lblErrorRegular.Visible = false;
            }
            else
            {
                lblErrorRegular.Visible = true;
                lblErrorRegular.Text = "Record Not Found.";
            }

            Boolean _flag = false;
            foreach (var item in bOrder.lsPartOrder)
            {
                if (item.NoofPartsOrders > 0)
                    _flag = true;
            }
            if (_flag)
            {
                litPartOrderQuantity.Text = cDonut.PartOrderQuantity(bOrder.lsPartOrder).ToHtmlString();
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Record Not Found.";
            }

            lblHoldOrder.Text = bOrder.HoldOrder.ToString();
            int ShippingInt = 0;
            int.TryParse(bOrder.lsshipped.ToString(), out ShippingInt);
            lblship.Text = ShippingInt.ToString();
        }

        private void FillInternal_Ticker()
        {
            try
            {
                string newShipment = "http://internal.kraususa.net/result.php?type=new";
                bOrder.WebReasponce(newShipment, lblNewSHipmentCount);
                String SYSInProcess = "http://internal.kraususa.net/result.php?type=processed_nywt";
                bOrder.WebReasponce(SYSInProcess, lblSysInProcess);
                String SYSShipped = "http://internal.kraususa.net/result.php?type=shipped_nywt";
                bOrder.WebReasponce(SYSShipped, lblSYSShipped);
                String PWInProcess = "http://internal.kraususa.net/result.php?type=processed";
                bOrder.WebReasponce(PWInProcess, lblPWInProcess);
                String PWShipped = "http://internal.kraususa.net/result.php?type=shipped_nywh";
                bOrder.WebReasponce(PWShipped, lblPWShipped);

            }
            catch (Exception)
            {
            }
        }



    }
}