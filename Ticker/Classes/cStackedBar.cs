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
        public static Highcharts GetTop_5_SKU_By_Ordered()
        {
            Highcharts chart = new Highcharts("StackedColumn")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 440,
                 Height = 200,
                 BackgroundColor = new BackColorOrGradient(new Gradient
                 {
                     LinearGradient = new[] { 0, 0, 0, 400 },
                     Stops = new object[,]
                  {
                    { 0, Color.FromArgb(13, 255, 255, 255) },
                    { 1, Color.FromArgb(13, 255, 255, 255) }
                  }
                 })
             }).SetCredits(new Credits
             {
                 Href = "http://www.kraususa.com/",
                 Text = "kraus USA Inc."
             })
             .SetTitle(new Title 
                            {
                                Text = "TOP 5 SKU ORDERED",
                                Style="color: '#fff'"
                            }
                       )
             .SetXAxis(new XAxis
                 {
                     Categories = new String[] { "PU-10CH", "KBU21", "KPF300", "KSD20", "KPF-1612"}
                })
            .SetYAxis(new YAxis
                {
                    Title = new YAxisTitle{ Text= "Quantity",Style="color: '#fff'"}
                })

              .SetLegend(new Legend
                  {
                      Enabled = false,
                      BackgroundColor = new BackColorOrGradient(System.Drawing.Color.Transparent),
                      Align = HorizontalAligns.Right,
                      VerticalAlign = VerticalAligns.Middle,
                      Layout = Layouts.Vertical
                  })
             .SetPlotOptions(new PlotOptions
             {
                 Column = new PlotOptionsColumn
                     {
                         PointWidth = 30,
                         DataLabels = new PlotOptionsColumnDataLabels
                             {
                                 Enabled = true,
                                 Rotation = -90,
                                 Color = ColorTranslator.FromHtml("#fff"),
                                 Align = HorizontalAligns.Right,
                             }
                     }
             })
             .SetSeries(new[]
                       {
                           new Series { Name = "Quantity", Data = new Data(new object[] { 17, 10, 10, 10,12 })  },
                       });
            return chart;
        }

        public static Highcharts GetTop_5_Partner_By_Ordered()
        {
            Highcharts chart = new Highcharts("StackedColumnPartner")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 440,
                 Height = 200,
                 BackgroundColor = new BackColorOrGradient(new Gradient
                 {
                     LinearGradient = new[] { 0, 0, 0, 400 },
                     Stops = new object[,]
                  {
                    { 0, Color.FromArgb(13, 255, 255, 255) },
                    { 1, Color.FromArgb(13, 255, 255, 255) }
                  }
                 })
             }).SetCredits(new Credits
             {
                 Href = "http://www.kraususa.com/",
                 Text = "kraus USA Inc."
             })
             .SetTitle(new Title
             {
                 Text = "TOP 5 PARTNER BY SKU QUANTITY ",
                 Style = "color: '#fff'"
             }
                       )
             .SetXAxis(new XAxis
             {
                 Categories = new String[] { "BUILD.COM", "EXpressDecor", "HomeDepot", "Amazon", "asdvs" }
             })
            .SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "SKU Quantity", Style = "color: '#eaeaea'" }
            })

              .SetLegend(new Legend
              {
                  Enabled = false,
                  BackgroundColor = new BackColorOrGradient(System.Drawing.Color.Transparent),
                  Align = HorizontalAligns.Right,
                  VerticalAlign = VerticalAligns.Middle,
                  Layout = Layouts.Vertical
              })
             .SetPlotOptions(new PlotOptions
             {
                 Column = new PlotOptionsColumn
                 {
                     PointWidth = 30,
                     DataLabels = new PlotOptionsColumnDataLabels
                     {
                         Enabled = true,
                         Rotation = -90,
                         Color = ColorTranslator.FromHtml("#fff"),
                         Align = HorizontalAligns.Right,
                     }
                 }
             })
             .SetSeries(new[]
                       {
                           new Series { Name = "Partners", Data = new Data(new object[] { 17, 5, 15, 10,13 }) ,Color=System.Drawing.Color.Brown },
                       });
            return chart;
        }
    }
}