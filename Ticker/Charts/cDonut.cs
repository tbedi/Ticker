using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using Ticker.DataBase;
using Ticker.DataBase.BL;
using Ticker.Views;

namespace Ticker.Charts
{
    public static class cDonut
    {


        /// <summary>
        /// This method is for OrderCanceled Donut  
        /// </summary>
        /// <param name="lsQuantityOrderCategory">
        /// List of Qauntity Category pass as parameter.
        /// </param>
        /// <returns>
        /// return Chart.
        /// </returns>
        public static Highcharts OrderCategory(List<OrderDTO> lsQuantityOrderCategory)
        {
            List<OrderDTO> CategotyDataFotChart = lsQuantityOrderCategory;


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
                    }),
                    Height = 200,
                    Width = 494,
                    ZoomType = ZoomTypes.Xy,

                })
                .SetCredits(new Credits
                {
                    Href = "http://www.kraususa.com/",
                    Text = "kraus USA Inc."
                })
                .SetTitle(new Title
                    {

                        Text = "",
                    })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ Math.round(this.percentage) +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        InnerSize = new PercentageOrPixel(60, true),
                        Cursor = Cursors.Auto,
                        Size = new PercentageOrPixel(90, true),
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Distance = 5,
                            Color = ColorTranslator.FromHtml("#fffff"),
                            ConnectorColor = ColorTranslator.FromHtml("#00000"),
                            Style="FontName: 'Arial'",
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ Math.round(this.percentage)+'%'; }"
                        },
                        Point = new PlotOptionsPiePoint
                        {

                            Events = new PlotOptionsPiePointEvents
                            {
                                //Click = "function() { alert (this.category +': '+ this.y); }"
                            }
                        }
                    }

                }).SetOptions(new GlobalOptions
                {
                    Colors = new Color[]
                    {
                       // ColorTranslator.FromHtml("#F38630"),
                       ColorTranslator.FromHtml("#EED4BE"),
                         ColorTranslator.FromHtml("#F28563"),
                          ColorTranslator.FromHtml("#949FB1"),
                        ColorTranslator.FromHtml("#4D5360"),
                          ColorTranslator.FromHtml("#DB1FD2"),
                        ColorTranslator.FromHtml("#F7464A"),
                        ColorTranslator.FromHtml("#D4CCC5"),
                       ColorTranslator.FromHtml("#FFA24A"),
                       ColorTranslator.FromHtml("#EEF6B3"),
                        ColorTranslator.FromHtml("#E0E4CC"),
                        ColorTranslator.FromHtml("#69D2E7"),
                         ColorTranslator.FromHtml("#96EAF0"),
                        ColorTranslator.FromHtml("#ED561B"),
                        ColorTranslator.FromHtml("#DF7EE6"),
                        ColorTranslator.FromHtml("#C79EF5"),
                        ColorTranslator.FromHtml("#98C1F2"),
                        ColorTranslator.FromHtml("#96F0CD"),
                        ColorTranslator.FromHtml("#BDE996"),
                        ColorTranslator.FromHtml("#2DDD68"),
                         ColorTranslator.FromHtml("#661CCD"),
                        //ColorTranslator.FromHtml("#"),
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Browser share",
                    Data = new Data(CategotyDataFotChart.ToPieChartSeries())
                });
            return chart;
        }
        
        /// <summary>
        /// This Method is for Regular order Donut.
        /// </summary>
        /// <param name="lsRegularOrder">
        /// Regular OrderDTO pass as parameter.
        /// </param>
        /// <returns>
        /// Return HighChart.
        /// </returns>
        public static Highcharts RegularOrder(List<AmountOrderDTO> lsRegularOrder)
        {
            List<AmountOrderDTO> ChartSriesData = lsRegularOrder;

            Highcharts chart = new Highcharts("chartRegular")
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
                    }),
                    Height = 200,
                    Width = 494,
                    ZoomType = ZoomTypes.Xy,
                }).SetCredits(new Credits
                {
                    Href = "http://www.kraususa.com/",
                    Text = "kraus USA Inc."
                })
                .SetTitle(new Title
                {

                    Text = "",
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ Math.round(this.percentage) +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        InnerSize = new PercentageOrPixel(60, true),
                        Cursor = Cursors.Auto,
                        Size = new PercentageOrPixel(90, true),
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Distance = 5,
                            Color = ColorTranslator.FromHtml("#fffff"),
                            ConnectorColor = ColorTranslator.FromHtml("#00000"),
                            Style = "FontName: 'Arial'",
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ '$'+Math.round(this.percentage); }"
                        },
                        Point = new PlotOptionsPiePoint
                        {

                            Events = new PlotOptionsPiePointEvents
                            {
                                //Click = "function() { alert (this.category +': '+ this.y); }"
                            }
                        }
                    }

                })
                .SetOptions(new GlobalOptions
                {
                    Colors = new Color[]
                    {
                       // ColorTranslator.FromHtml("#F38630"),
                       ColorTranslator.FromHtml("#EED4BE"),
                         ColorTranslator.FromHtml("#F28563"),
                          ColorTranslator.FromHtml("#949FB1"),
                        ColorTranslator.FromHtml("#4D5360"),
                          ColorTranslator.FromHtml("#DB1FD2"),
                        ColorTranslator.FromHtml("#F7464A"),
                        ColorTranslator.FromHtml("#D4CCC5"),
                       ColorTranslator.FromHtml("#FFA24A"),
                       ColorTranslator.FromHtml("#EEF6B3"),
                        ColorTranslator.FromHtml("#E0E4CC"),
                        ColorTranslator.FromHtml("#69D2E7"),
                         ColorTranslator.FromHtml("#96EAF0"),
                        ColorTranslator.FromHtml("#ED561B"),
                        ColorTranslator.FromHtml("#DF7EE6"),
                        ColorTranslator.FromHtml("#C79EF5"),
                        ColorTranslator.FromHtml("#98C1F2"),
                        ColorTranslator.FromHtml("#96F0CD"),
                        ColorTranslator.FromHtml("#BDE996"),
                        ColorTranslator.FromHtml("#2DDD68"),
                         ColorTranslator.FromHtml("#661CCD"),
                        //ColorTranslator.FromHtml("#"),
                    }
                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Browser share",
                    Data = new Data(ChartSriesData.ToDonutchartAmountOrder())
                });
            return chart;
        }

        /// <summary>
        /// This Method is for Partorder Donut.
        /// </summary>
        /// <param name="lsPartOrder">
        /// Part orderDTO pass as parameter.
        /// </param>
        /// <returns>
        /// Return Chart.
        /// </returns>
        public static Highcharts PartOrderQuantity(List<PartOrderDTO> lsPartOrder)
        {
            List<PartOrderDTO> ChartSeriesData = lsPartOrder;
            Highcharts chart = new Highcharts("chartParts")
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
                    }),
                    Height = 170,
                    Width = 250,
                    ZoomType = ZoomTypes.Xy,
                }).SetCredits(new Credits
                {
                    Href = "http://www.kraususa.com/",
                    Text = "kraus USA Inc."
                })
                .SetTitle(new Title
                {

                    Text = "",
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ Math.round(this.percentage) +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        InnerSize = new PercentageOrPixel(60, true),
                        Cursor = Cursors.Auto,
                        Size = new PercentageOrPixel(90, true),
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Distance = 5,
                            Color = ColorTranslator.FromHtml("#fffff"),
                            ConnectorColor = ColorTranslator.FromHtml("#fffff"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ Math.round(this.percentage)+'%'; }"
                        },
                        Point = new PlotOptionsPiePoint
                        {

                            Events = new PlotOptionsPiePointEvents
                            {
                                //Click = "function() { alert (this.category +': '+ this.y); }"
                            }
                        }
                    }

                })
                .SetSeries(new Series
                {
                    Type = ChartTypes.Pie,
                    Name = "Browser share",
                    Data = new Data(ChartSeriesData.TOPiChartPartOrder())
                });
            return chart;
        }

    }
}
