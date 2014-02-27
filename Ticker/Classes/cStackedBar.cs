using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Ticker.BI;
using Ticker.Classes;

namespace Ticker.Classes
{
    public class cStackedBar
    {
        public static BIOrder bOrder = new BIOrder();
        public static DataBase.Command.cmdClass cmd = new DataBase.Command.cmdClass();

        public static List<Views.TopQuantityOrdered>  lsTopSKUQty= cmd.GetTop5SkuQuantityOrder();
        public static List<Views.TopPartnerDTO> lsTopPartners = cmd.GetTop5ParnerOrder();
        public static Highcharts GetTop_5_SKU_By_Ordered()
        {
            Highcharts chart = new Highcharts("StackedColumn")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 470,
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

                     Categories = lsTopSKUQty.ToCatagorysListFromSKU(),
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
                           new Series { Name = "Quantity", Data =new Data( lsTopSKUQty.ToTop5SKUObject())  },
                       });
            return chart;
        }

        public static Highcharts GetTop_5_Partner_By_Ordered()
        {
            Highcharts chart = new Highcharts("StackedColumnPartner")
             .InitChart(new Chart
             {
                 DefaultSeriesType = ChartTypes.Column,
                 Width = 405,
                 Height = 400,
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
                 Categories = lsTopPartners.ToCatagorysListFromPartner()
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
                         Color = ColorTranslator.FromHtml("#fff"),
                         Align = HorizontalAligns.Center,
                         VerticalAlign = VerticalAligns.Middle,
                         Y = -5
                     }
                 }
             })
             .SetSeries(new[]
                       {
                           new Series { Name = "Partners", Data = new Data(lsTopPartners.ToTop5ParnerObject()) ,Color=System.Drawing.Color.FromArgb(1,80, 150, 18) },
                       });
            return chart;
        }
    }
}