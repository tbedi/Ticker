using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
namespace Ticker.Classes
{
    public class cPichart 
    {
        public Highcharts GetPichart()
        {
            Highcharts chart = new Highcharts("chart")
          .InitChart(new Chart
          {
              PlotShadow = false,
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
          .SetTitle(new Title { Text = "Browser market shares at a specific website, 2010" })
          .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
          .SetPlotOptions(new PlotOptions
          {
              Pie = new PlotOptionsPie
              {
                  AllowPointSelect = true,
                  Cursor = Cursors.Pointer,
                  DataLabels = new PlotOptionsPieDataLabels
                  {
                      Color = ColorTranslator.FromHtml("#000000"),
                      ConnectorColor = ColorTranslator.FromHtml("#000000"),
                      Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                  }
              }
          })
          .SetSeries(new Series
          {
              Type = ChartTypes.Pie,
              Name = "Browser share",
              Data = new Data(new object[]
                                       {
                                           new object[] { "Firefox", 45.0 },
                                           new object[] { "IE", 26.8 },
                                           new DotNet.Highcharts.Options.Point
                                           {
                                               Name = "Chrome",
                                               Y = 12.8,
                                               Sliced = true,
                                               Selected = true
                                           },
                                           new object[] { "Safari", 8.5 },
                                           new object[] { "Opera", 6.2 },
                                           new object[] { "Others", 0.7 }
                                       })
          });

            return chart;
        }
    
    }
}