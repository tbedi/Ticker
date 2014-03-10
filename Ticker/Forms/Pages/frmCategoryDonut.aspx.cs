using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.Charts;
using Ticker.DataBase.BL;

namespace Ticker.Forms.Pages
{
    public partial class frmCategoryDonut : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CREATE NEW Object calls database..
                cGlobal.Border = new blOrder();
                DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();

                lblNewOrderNH.Text = (Convert.ToInt32(cGlobal.Border.GetTotalOrder(cGlobal.Border.lsQuantityOrderCategory))).ToString();

                ltrChart.Text = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();
                
            }
           // String Script = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();

              lblNewOrderNH.Text = (Convert.ToInt32(cGlobal.Border.GetTotalOrder(cGlobal.Border.lsQuantityOrderCategory))).ToString();

             ltrChart.Text = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();

            //String Script = cDonut.OrderCategory(cmd.GetQuantityOrderedCategory()).ToHtmlString();
        }
    }
}