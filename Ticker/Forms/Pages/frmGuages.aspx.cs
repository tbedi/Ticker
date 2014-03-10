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
    public partial class frmGuages : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillInternal_Ticker();
            }
        }
        private void FillInternal_Ticker()
        {
            try
            {
                blTicker _ticker = new blTicker();
                //string newShipment = "http://internal.kraususa.net/result.php?type=new";

                List<int> lsneworder = _ticker.GetNewOrder();
                Literal1.Text = cGuage.GetNewShipmentGuage(Convert.ToInt32(lsneworder[0].ToString())).ToHtmlString();

                List<int> lSYSProcess = _ticker.GetSYSProcessingTicker();
                //String SYSInProcess = "http://internal.kraususa.net/result.php?type=processed_nywt";
                ltrInProcessSOS.Text = cGuage.GetGreenSYS(Convert.ToInt32(lSYSProcess[0].ToString())).ToHtmlString();


                //String SYSShipped = "http://internal.kraususa.net/result.php?type=shipped_nywt";
                ltrShippedSYS.Text = cGuage.GetPurplSYS(Convert.ToInt32(_ticker.GetSYSShippedTicker()[0].ToString())).ToHtmlString();

                //String PWInProcess = "http://internal.kraususa.net/result.php?type=processed";

                ltrInprocessNyWH.Text = cGuage.GetGreenWT((Convert.ToInt32(_ticker.GetNYWHProcessingTicker()[0].ToString()))).ToHtmlString();
                //String PWShipped = "http://internal.kraususa.net/result.php?type=shipped_nywh";
                ltrShippedNYWH.Text = cGuage.GetPurplWT((Convert.ToInt32(_ticker.GetNYWHShippedTicker()[0].ToString()))).ToHtmlString();

                DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
                List<double> lsshipped = new List<double>();
                lsshipped = cmd.GetShipped();

                lblHoldOrder.Text = cmd.GetNoOfHoldOrders().ToString();
                int ShippingInt = 0;
                string Ship = Math.Round(lsshipped.ToShippedpercentage(), 0).ToString();
                int.TryParse(Ship, out ShippingInt);
                lblship.Text = ShippingInt.ToString() + "%";


            }
            catch (Exception)
            {
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            FillInternal_Ticker();
        }
    }
}