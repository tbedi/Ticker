using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Ticker.DataBase.BL;
using Ticker.Charts;
using Ticker.Views;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace Ticker.Charts
{
    public class cStackedBar
    {
        /// <summary>
        /// This Method is for Stacked Column of Top 5 SKU By order.
        /// </summary>
        /// <param name="lstopQuantityorder">
        /// topQuantityOrderDTO Pass as parameter.
        /// </param>
        /// <returns>
        /// Return Chart.
        /// </returns>
        public static Highcharts GetTop_5_SKU_By_Ordered(List<TopQuantityOrdered> lstopQuantityorder)
        {
            Highcharts chart = new Highcharts("StackedColumn")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 500,
                 Height = 365,
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
                                Text = "TOP SKU ORDERED BY QUANTITY",
                                Style = "color: '#fff'"
                            }
                       )
             .SetXAxis(new XAxis
                 {
                     Labels = new XAxisLabels { Style = "color: '#fff'" },
                     Categories = lstopQuantityorder.ToCatagorysListFromSKU()
                 })
            .SetYAxis(new YAxis
                {
                    Labels = new YAxisLabels { Style = "color: '#fff'" },
                    Title = new YAxisTitle { Text = "", Style = "color: '#fff'" }
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
                         PointWidth = 40,
                         DataLabels = new PlotOptionsColumnDataLabels
                             {
                                 Enabled = true,
                                 Color = ColorTranslator.FromHtml("#fff"),
                                 Align = HorizontalAligns.Center,
                                 VerticalAlign = VerticalAligns.Middle,
                                 Y = -5
                             }
                     }
             })

             .SetSeries(new[]
                       {
                           new Series { Name = "Quantity", Data =new Data( lstopQuantityorder.ToTop5SKUObject())  },
                       });
            return chart;
        }

        /// <summary>
        /// This Method is Stacked Column for Toppartner Orders.
        /// </summary>
        /// <param name="lstopPartner">
        /// top PartnerDTO Pass as parameter.
        /// </param>
        /// <returns>
        /// Return Chart.
        /// </returns>
        public static Highcharts GetTop_5_Partner_By_Sales(List<TopPartnerDTO> lstopPartner)
        {
            Highcharts chart = new Highcharts("StackedColumnPartner")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 500,
                 Height = 365,
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
                 Text = "TOP PARTNER BY SALES",
                 Style = "color: '#fff'"
             }
                       )
             .SetXAxis(new XAxis
             {
                 Categories = lstopPartner.ToCatagorysListFromPartner(),
                 Labels = new XAxisLabels { Style="color: '#fff'"}
             })
            .SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "", Style = "color: 'whitesmoke'" },
                Labels = new YAxisLabels { Style="color: '#fff'"}
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
                         Color = ColorTranslator.FromHtml("#fff"),
                         Align = HorizontalAligns.Center,
                         VerticalAlign = VerticalAligns.Middle,
                         Y = -10,
                         Formatter = "function() {return  '$'+this.y}"
                     }
                 }
             })
             .SetSeries(new[]
                       {
                           new Series { Name = "Partners", Data = new Data(lstopPartner.ToTop5ParnerObject())  },
                       });
            return chart;
        }

        /// <summary>
        /// This Method is Stacked Column for Toppartner sales.
        /// </summary>
        /// <param name="lstopPartner">
        /// top PartnerDTO Pass as parameter.
        /// </param>
        /// <returns>
        /// Return Chart.
        /// </returns>
        public static Highcharts GetTop_5_Partner_By_OrderCount(List<TopPartnerDTO> lstopPartnerByOrder)
        {
            Highcharts chart = new Highcharts("StackedColumnPartnerByorderCount")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 500,
                 Height = 365,
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
                 Text = "TOP PARTNER BY ORDER",
                 Style = "color: '#fff'"
             }
                       )
             .SetXAxis(new XAxis
             {
                 Categories = lstopPartnerByOrder.ToCatagorysListFromPartner(),
                 Labels = new XAxisLabels { Style = "color: '#fff'" }
             })
            .SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "", Style = "color: 'whitesmoke'" },
                Labels = new YAxisLabels { Style = "color: '#fff'" }
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
                         Color = ColorTranslator.FromHtml("#fff"),
                         Align = HorizontalAligns.Center,
                         VerticalAlign = VerticalAligns.Middle,
                         Y = -10,
                         //Formatter = "function() {return  '$'+this.y}"
                     }
                 }
             })
             .SetSeries(new[]
                       {
                           new Series { Name = "Partners", Data = new Data(lstopPartnerByOrder.ToTop5ParnerObject())  },
                       });
            return chart;
        }
    }
}