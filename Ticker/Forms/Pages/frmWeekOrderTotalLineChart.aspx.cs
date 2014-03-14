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
        {if(!IsPostBack)
            FillChart();
        }
        public void FillChart()
        {
            DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();
            List<WeekOrederDTO> lsAllWeeks= cmd.GetWeekOrders();
            ltrWeekToatalLineChart.Text = Charts.cLine.WeeklyTotalOrders(ThisWeekData(lsAllWeeks), lastWeekData(lsAllWeeks), YearDat(cmd.GetYearAvg())).ToHtmlString();
        }

        public List<Object> lastWeekData(List<WeekOrederDTO> lsData)
        {
            List<object> _return = new List<object>();
            try
            {
                DateTime LastweekSratdate = DataBase.BL.ExtensionMethods.LastWeekStartDate();
                DateTime LastWeekEndDate = LastweekSratdate.AddDays(7);
                // List<WeekOrederDTO> lslastWeek = lsData.Where(i =>i.date>=LastweekSratdate && i.date<=LastWeekEndDate);
                var v = (from ls in lsData.AsParallel()
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
                var v = (from ls in lsData.AsParallel()
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

        public List<Object> YearDat(List<YearAvg> lsData)
        {
            List<Object> _lsreturn = new List<object>();
            try
            {

                Object item = lsData.SingleOrDefault(i => i.DayName == "Monday").Avarage;
                _lsreturn.Add(item);
                Object item1 = lsData.SingleOrDefault(i => i.DayName == "Tuesday").Avarage;
                _lsreturn.Add(item1);
                Object item2 = lsData.SingleOrDefault(i => i.DayName == "Wednesday").Avarage;
                _lsreturn.Add(item2);
                Object item3 = lsData.SingleOrDefault(i => i.DayName == "Thursday").Avarage;
                _lsreturn.Add(item3);
                Object item4 = lsData.SingleOrDefault(i => i.DayName == "Friday").Avarage;
                _lsreturn.Add(item4);
                 Object item5 = lsData.SingleOrDefault(i => i.DayName == "Saturday").Avarage;
                _lsreturn.Add(item5);
                 Object item7 = lsData.SingleOrDefault(i => i.DayName == "Sunday").Avarage;
                _lsreturn.Add(item7);
            }
            catch (Exception)
            {}
            return _lsreturn;
        }




        protected void Timer1_Tick(object sender, EventArgs e)
        {
            FillChart();
        }
    }
}