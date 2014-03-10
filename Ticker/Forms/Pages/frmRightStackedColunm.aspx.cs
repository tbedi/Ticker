using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Charts;
using Ticker.DataBase.BL;
using Ticker.Views;

namespace Ticker.Forms.Pages
{
    public partial class frmRightStackedColunm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Stacked();
            }
        }
        private void Stacked()
        {
            DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
            List<TopPartnerDTO> lstopPartnerByOrder = new List<TopPartnerDTO>();
            List<TopPartnerDTO> lstopPartner = new List<TopPartnerDTO>();
            lstopPartner = cmd.GetTop5ParnerSale();
            lstopPartnerByOrder = cmd.GetTop5ParnerByOrder();
            if (lstopPartnerByOrder.Count > 0)
                ltrTOPPartnerByOrder.Text = cStackedBar.GetTop_5_Partner_By_OrderCount(lstopPartnerByOrder).ToHtmlString();


            if (lstopPartner.Count > 0)
                ltrStackedColumnTop5Partner.Text = cStackedBar.GetTop_5_Partner_By_Sales(lstopPartner).ToHtmlString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Stacked();
        }
    }
}