using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticker.Charts
{
    public static class cLine
    {

        public static Highcharts WeeklyTotalOrders()
        {
            Highcharts Chart = new Highcharts("Chart")
                 .InitChart(new Chart
                 {
                     Type = ChartTypes.Line,
                 })
                 .SetTitle(new Title
                 {
                    Text = "Shipment Packing Count"
                 })
                 .SetXAxis(new XAxis
                 {
                        Categories = new string[]{"Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"},
                        Title = new XAxisTitle { Text = "" }
                 })
                 .SetYAxis(new YAxis
                 {
                        Title = new YAxisTitle { Text = "Shipments packed" }
                 }).SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                   {
                       new Series { Name = "This Week", Data = new Data(new object[]{254,254,587,545,545,585,584}) },
                       new Series { Name = "Last Week", Data = new Data(new object[]{258,789,226,901,249,304,854}) }
                   });
         
            return Chart;
        }


    }
}
