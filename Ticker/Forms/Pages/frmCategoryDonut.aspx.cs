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
    public partial class frmCategoryDonut : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDonut();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            FillDonut();
        }


        public void FillDonut()
        {
            DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
            List<OrderDTO> lsOrderCount = new List<OrderDTO>();
            lsOrderCount = cmd.GetQuantityOrderedCategory();
            if (lsOrderCount.Count > 0)
            {

                lblNewOrderNH.Text = (Convert.ToInt32(lsOrderCount.ToTotalOrderCount())).ToString();

                ltrChart.Text = cDonut.OrderCategory(lsOrderCount.RemoveLessThenZero()).ToHtmlString();
            }


            List<AmountOrderDTO> lsOrderAmount = new List<AmountOrderDTO>();
            lsOrderAmount = cmd.GetAmountCategoryOrdred();
            if (lsOrderCount.Count > 0)
            {

                lbltotalamount.Text = (Convert.ToInt32(lsOrderAmount.ToTotalOrderAmount())).ToString();

                litOrderAmount.Text = cDonut.RegularOrder(lsOrderAmount.RemoveLessThanZeroAmountOrder()).ToHtmlString();
            }





        }
    }
}