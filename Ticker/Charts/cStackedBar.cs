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
                 Width = 495,
                 Height = 355,
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
                                Style = "color: 'Black', fontBold: 'true', fontSize: '20px'"
                                
                            }
                       )
             .SetXAxis(new XAxis
                 {
                     Labels = new XAxisLabels { Style = "color: 'Black',fontBold: 'true',fontSize: '14px'" },
                     Categories = lstopQuantityorder.ToCatagorysListFromSKU()
                 })
            .SetYAxis(new YAxis
                {
                    Labels = new YAxisLabels { Style = "color: 'Black'" },
                    Title = new YAxisTitle { Text = "", Style = "color: 'Black',fontBold: 'true'" }
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
                                 Color = ColorTranslator.FromHtml("#000000"),
                                 Align = HorizontalAligns.Center,
                                 VerticalAlign = VerticalAligns.Middle,
                                 Y = -5,
                                 Style="fontSize: '14px'"
                             },
                         BorderWidth = 2,
                         BorderColor = ColorTranslator.FromHtml("#FF6B00"),
                         Color = ColorTranslator.FromHtml("#FFA24A")
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
                 Height = 360,
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
                 Text = "TOP PARTNERS BY SALES",
                 Style = "color: 'Black', fontBold: 'true', fontSize: '20px'"
             }
                       )
             .SetXAxis(new XAxis
             {
                 Categories = lstopPartner.ToCatagorysListFromPartner(),
                 Labels = new XAxisLabels { Style = "color: 'Black',fontSize: '14px'" }
             })
            .SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "", Style = "color: 'Black'" },
                Labels = new YAxisLabels { Style = "color: 'Black'" }
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
                         Color = ColorTranslator.FromHtml("Black"),
                         Align = HorizontalAligns.Center,
                         VerticalAlign = VerticalAligns.Middle,
                         Y = -11,
                         Formatter = "function() {return  '$'+this.y}",
                         Style = "fontSize: '14px'"
                     },
                     BorderWidth = 2,
                     BorderColor = ColorTranslator.FromHtml("#FF6B00")
                 }
             })
             .SetSeries(new[]
                {
                    new Series { Name = "Partners", Data = new Data(lstopPartner.ToTop5ParnerObject())  },
                })
                .SetOptions(new GlobalOptions
                {
                    Colors = new Color[]
                    {
                       // ColorTranslator.FromHtml("#F38630"),
                       ColorTranslator.FromHtml("#FFA24A"),
                        ColorTranslator.FromHtml("#E0E4CC"),
                        ColorTranslator.FromHtml("#69D2E7"),
                        ColorTranslator.FromHtml("#661CCD"),
                        ColorTranslator.FromHtml("#ED561B"),
                        ColorTranslator.FromHtml("#DF7EE6"),
                        ColorTranslator.FromHtml("#C79EF5"),
                        ColorTranslator.FromHtml("#98C1F2"),
                        ColorTranslator.FromHtml("#96EAF0"),
                        ColorTranslator.FromHtml("#96F0CD"),
                        ColorTranslator.FromHtml("#BDE996"),
                        ColorTranslator.FromHtml("#EEF6B3"),
                        ColorTranslator.FromHtml("#EED4BE"),
                        ColorTranslator.FromHtml("#F28563"),
                        ColorTranslator.FromHtml("#DB1FD2"),
                        ColorTranslator.FromHtml("#F7464A"),
                        ColorTranslator.FromHtml("#E2EAE9"),
                        ColorTranslator.FromHtml("#D4CCC5"),
                        ColorTranslator.FromHtml("#949FB1"),
                        ColorTranslator.FromHtml("#4D5360"),
                        ColorTranslator.FromHtml("#2DDD68"),
                        
                        //ColorTranslator.FromHtml("#"),

                    }
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
                 Height = 360,
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
                 Text = "TOP PARTNERS BY # OF ORDERS",
                 Style = "color: 'Black', fontBold: 'true', fontSize: '20px'"
             })
             .SetXAxis(new XAxis
             {
                 Categories = lstopPartnerByOrder.ToCatagorysListFromPartner(),
                 Labels = new XAxisLabels { Style = "color: 'Black',fontSize: '12px'" }
             })
            .SetYAxis(new YAxis
            {
                Title = new YAxisTitle { Text = "", Style = "color: 'Black'" },
                Labels = new YAxisLabels { Style = "color: 'Black'" }
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
                         Color = ColorTranslator.FromHtml("Black"),
                         Align = HorizontalAligns.Center,
                         VerticalAlign = VerticalAligns.Middle,
                         Y = -10,
                         Style = "fontSize: '14px'"
                         //Formatter = "function() {return  '$'+this.y}"
                     },
                     BorderWidth=2,
                     BorderColor = ColorTranslator.FromHtml("#FF6B00")
                     //Color = ColorTranslator.FromHtml("#E94C4C"),

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