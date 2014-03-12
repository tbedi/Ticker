using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ticker.DataBase.Views;

namespace Ticker.Forms.Pages
{
    public partial class frmWeekOrderTotalLineChart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillChart();
        }
        public void FillChart()
        {
            DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
            List<WeekOrederDTO> lsAllWeeks= cmd.GetWeekOrders();
            ltrWeekToatalLineChart.Text = Charts.cLine.WeeklyTotalOrders(ThisWeekData(lsAllWeeks), lastWeekData(lsAllWeeks)).ToHtmlString();
        }

        public List<Object> lastWeekData(List<WeekOrederDTO> lsData)
        {
            List<object> _return = new List<object>();
            try
            {
                DateTime LastweekSratdate = DataBase.BL.ExtensionMethods.LastWeekStartDate();
                DateTime LastWeekEndDate = LastweekSratdate.AddDays(7);
                // List<WeekOrederDTO> lslastWeek = lsData.Where(i =>i.date>=LastweekSratdate && i.date<=LastWeekEndDate);
                var v = (from ls in lsData
                         where ls.date.Date >= LastweekSratdate.Date && ls.date.Date < LastWeekEndDate.Date
                         select ls).OrderBy(j => j.date).ToList();

                foreach (var item in v)
                {
                    _return.Add(item.Orders);
                }
            }
            catch (Exception)
            { }
            return _return;
        }

        public List<Object> ThisWeekData(List<WeekOrederDTO> lsData)
        {
            List<object> _return = new List<object>();
            try
            {
                DateTime thisweekStartDate = DataBase.BL.ExtensionMethods.LastWeekStartDate().AddDays(7);
                var v = (from ls in lsData
                         where ls.date.Date >= thisweekStartDate.Date
                         select ls).OrderBy(j => j.date).ToList();

                foreach (var item in v)
                {
                    _return.Add(item.Orders);
                }
            }
            catch (Exception)
            { }
            return _return;
        }
    }
}