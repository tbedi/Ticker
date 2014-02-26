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
    public static class cDonut
    {
        public static  Highcharts OrderCanceledDonut()
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
                    }),
                    Height = 200,
                    Width = 270,
                    ZoomType = ZoomTypes.Xy,
                })
                .SetTitle(new Title 
                    { 
                        Text = "ORDER CANCELED TODAY", 
                        Align = HorizontalAligns.Left,
                        VerticalAlign = VerticalAligns.Top,
                        Style = "color: '#FFF'",
                        Floating=true,
                    })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        InnerSize = new PercentageOrPixel(60, true),
                        Cursor = Cursors.Pointer,
                        Size = new PercentageOrPixel(80, true),
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Distance = 0,
                            Color = ColorTranslator.FromHtml("#232222"),
                            ConnectorColor = ColorTranslator.FromHtml("#808080"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage; }"
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
                    Data = new Data(new object[]
                                           {
                                               new object[] { "SOW", 18 },
                                               new object[] { "SOPR", 12, },
                                               new object[] { "SOI", 20, },
                                               new object[] { "SOEP", 50, }
                                           })
                });
            return chart;
        }
        public static Highcharts OrderHoldDonut()
        {
            Highcharts chart = new Highcharts("charta")
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
                    Width = 270,
                    ZoomType = ZoomTypes.Xy,
                })
                .SetTitle(new Title
                {
                    Text = "ORDER ON HOLD",
                    Align = HorizontalAligns.Left,
                    VerticalAlign = VerticalAligns.Top,
                    Style = "color: '#FFF'",
                    Floating = true,
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
                .SetPlotOptions(new PlotOptions
                {
                    Pie = new PlotOptionsPie
                    {
                        AllowPointSelect = true,
                        InnerSize = new PercentageOrPixel(60, true),
                        Cursor = Cursors.Pointer,
                        Size = new PercentageOrPixel(80, true),
                        DataLabels = new PlotOptionsPieDataLabels
                        {
                            Distance = 0,
                            Color = ColorTranslator.FromHtml("#232222"),
                            ConnectorColor = ColorTranslator.FromHtml("#808080"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage; }"
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
                    Name = "Category",
                    Data = new Data(new object[]
                                           {
                                               new object[] { "SOW", 28 },
                                               new object[] { "SOPR", 22, },
                                               new object[] { "SOI", 10, },
                                               new object[] { "SOEP", 40, }
                                           })
                });
            return chart;
        }
    }
}
