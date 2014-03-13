﻿using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Runtime.InteropServices;

namespace Ticker.Charts
{
    public static class cLine
    {

        public static Highcharts WeeklyTotalOrders(List<object>ThisWeek, List<object> LastWeek ,[Optional, DefaultParameterValue(null)] List<Object> lsYearAvg )
        {
            Highcharts Chart = new Highcharts("Chart")
                 .InitChart(new Chart
                 {
                     Type = ChartTypes.Line,
                     Width = 495,
                     Height = 270
                 })
                 .SetTitle(new Title
                 {
                     Text = "TOTAL ORDERS BY WEEK",

                     Style = "color: 'Black', fontBold: 'true', fontSize: '15px',fontFamily: 'Arial'"
                 }).SetExporting(new Exporting{Enabled=false})
                 .SetXAxis(new XAxis
                 {
                     Categories = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" },
                     Title = new XAxisTitle { Text = "" },

                 }).SetPlotOptions(new PlotOptions
                 {
                     Line = new PlotOptionsLine
                     {
                         DataLabels = new PlotOptionsLineDataLabels
                         {
                             Enabled = false,
                             Y = -4,
                             X = 10,
                             Style = "fontSize: '10px' ,color: 'Black',fontFamily: 'Arial'"
                         },
                     }
                 })
                 .SetYAxis(new YAxis
                 {
                     Title = new YAxisTitle { Text = "" },
                 }).SetCredits(new Credits { Enabled = false })
                 .SetSeries(new[]
                   {
                       new Series { Name = "This Week", Data = new Data(ThisWeek.ToArray()) , Color = ColorTranslator.FromHtml("#70C133")},
                       new Series { Name = "Last Week", Data = new Data(LastWeek.ToArray()) , Color = ColorTranslator.FromHtml("#007acc")},
                       new Series { Name = "This Year", Data = new Data(lsYearAvg.ToArray()) , Color = ColorTranslator.FromHtml("#6E6E6E") , PlotOptionsLine = new PlotOptionsLine{ DashStyle= DashStyles.LongDash}}
                   });
         
            return Chart;
        }


    }
}
