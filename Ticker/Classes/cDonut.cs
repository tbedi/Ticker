using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Drawing;
using Ticker.BI;

namespace Ticker.Classes
{
    public static class cDonut
    {
       public static BIOrder b = new BIOrder();
        public static Highcharts OrderCanceledDonut()
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
                    Height = 370,
                    Width = 470,
                    ZoomType = ZoomTypes.Xy,
                    
                }).SetCredits( new Credits
                {
                    Href = "http://www.kraususa.com/",
                    Text="kraus USA Inc."
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
                    Data = new Data(b.GetQuantityOrderCat().ToPieChartSeries())
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
                    Height = 270,
                    Width = 370,
                    ZoomType = ZoomTypes.Xy,
                }).SetCredits(new Credits
                {
                    Href = "http://www.kraususa.com/",
                    Text = "kraus USA Inc."
                })
                .SetTitle(new Title
                {
                    Text = ""
                   
                })
                .SetTooltip(new Tooltip { Formatter = "function() { return '<b style=\" fontsize:15px\">'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
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
                            Color = ColorTranslator.FromHtml("#232222"),
                            ConnectorColor = ColorTranslator.FromHtml("#fffff"),
                            Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+this.percentage; }"
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

        public static Highcharts RegularOrder()
        {

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
                    Height = 170,
                    Width = 250,
                    ZoomType = ZoomTypes.Xy,
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
                    Data = new Data(b.GetRegularOrderQuantity().RegularOrder())
                });
            return chart;
        }
        public static Highcharts PartOrderQuantity()
        {

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
                    Height = 200,
                    Width = 250,
                    ZoomType = ZoomTypes.Xy,
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
                    Data = new Data(b.GetPartOrderQuantity().PartOrder())
                });
            return chart;
        }

    }
}
