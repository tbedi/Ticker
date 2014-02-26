using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Ticker.Classes
{
    public class cStackedBar
    {
        public static Highcharts GetStackedBar()
        {
            Highcharts chart = new Highcharts("chart")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 500,
                 BackgroundColor = new BackColorOrGradient(new Gradient 
                 {
                  LinearGradient = new[] { 0, 0, 0, 400 },
                  Stops = new object[,]
                  {
                    { 0, Color.FromArgb(13, 255, 255, 255) },
                    { 1, Color.FromArgb(13, 255, 255, 255) }
                  }
                 })
             })
             .SetTitle(new Title { Text = "Stacked column chart" })
             .SetXAxis(new XAxis
             {
                 Categories = new[] { "Champ 1", "Champ 2", "Champ 3", "Champ 4", "Champ 5", "Champ 6" }
             })
             .SetPlotOptions(new PlotOptions { Column = new PlotOptionsColumn { Stacking = Stackings.Normal, PointWidth = 30 } })
             .SetSeries(new[]
                       {
                           new Series { Name = "Audio", Data = new Data(new object[] { 17, 2, 10, 10,12,8 }) },
                           new Series { Name = "Video", Data = new Data(new object[] { 15, 5, 3, 3,5,8 }) },
                           new Series { Name = "Peripheral", Data = new Data(new object[] { 6, 16, 16, 16,5,16 }) }
                       });
            return chart;
        }
    }
}