using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Ticker.Charts
{
    public static class cGuage
    {
        public static Highcharts GetNewShipmentGuage( int DataValue )
        {
            Highcharts chart = new Highcharts("chartgauge")
               .InitChart(new Chart
               {

                   Width = 500,

                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
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

               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title
               {
                   Text = "",
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom

               })
               .SetPane(new Pane
               {
                   StartAngle = -120,
                   EndAngle = 120,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 400 },
                                                Stops = new object[,]
                                                    {
                                                        { 0, Color.FromArgb(13, 255, 255, 255) },
                                                        { 1, Color.FromArgb(13, 255, 255, 255) }
                                                    }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                       OuterRadius = new PercentageOrPixel(0, true),
                                    }
                                   
                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = 0,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '50px' ,color: '#5fc0fe'",
                           BorderWidth = 0

                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 750,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 20,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 5,
                   TickColor = ColorTranslator.FromHtml("#007acc"),
                   Labels = new YAxisLabels
                   {
                       Step = 3,
                       Distance = -20,
                       Style="color: '#fff'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands 
                                {
                                    From = 0, To = 750, 
                                    Color = ColorTranslator.FromHtml("#007acc"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                
                            },
               })
               .SetSeries(new Series
               {
                   Name = "New",
                   Data = new Data(new object[] { DataValue }),
                   YAxis = "0",
                   PlotOptionsGauge = new PlotOptionsGauge
                   {
                       Dial = new PlotOptionsGaugeDial
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {

                               LinearGradient = new[] { 95,196,254, 1 },
                               Stops = new object[,] { { 0, "#007acc" }, { 1, "#007acc" } }
                           })
                       },
                       Pivot = new PlotOptionsGaugePivot
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#007acc" }, { 1, "#007acc" } }
                           })
                       }
                   }

               });

            return chart;
       
        }

        public static Highcharts GetGreenSYS(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugeGreenSYS")
               .InitChart(new Chart
               {
                   Width = 200,
                   Height = 200,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
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

               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title
               {
                   Text = "",
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom

               })
               .SetPane(new Pane
               {
                   StartAngle = -120,
                   EndAngle = 120,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 400 },
                                                Stops = new object[,]
                                                    {
                                                        { 0, Color.FromArgb(13, 255, 255, 255) },
                                                        { 1, Color.FromArgb(13, 255, 255, 255) }
                                                    }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                       OuterRadius = new PercentageOrPixel(0, true),
                                    }
                                   
                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = 0,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '50px' ,color: 'Black'",
                           BorderWidth = 0

                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 750,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 20,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 5,
                   TickColor = ColorTranslator.FromHtml("#80a93b"),
                   Labels = new YAxisLabels
                   {
                       Step = 3,
                       Distance = -20,
                       Style = "color: '#fff'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands 
                                {
                                  From = 0, To = 750,
                                    Color = ColorTranslator.FromHtml("#80a93b"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                
                            },
               })
               .SetSeries(new Series
               {
                   Name = "New",
                   Data = new Data(new object[] { DataValue }),
                   YAxis = "0",
                   PlotOptionsGauge = new PlotOptionsGauge
                   {
                       Dial = new PlotOptionsGaugeDial
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#55BF3B" }, { 1, "#55BF3B" } }
                           })
                       },
                       Pivot = new PlotOptionsGaugePivot
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#55BF3B" }, { 1, "#55BF3B" } }
                           })
                       }
                   }
               });

            return chart;

        }
      
        public static Highcharts GetGreenWT(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugeGreenWT")
               .InitChart(new Chart
               {
                   Width = 200,
                   Height = 200,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
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

               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title
               {
                   Text = "",
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom

               })
               .SetPane(new Pane
               {
                   StartAngle = -120,
                   EndAngle = 120,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 400 },
                                                Stops = new object[,]
                                                    {
                                                        { 0, Color.FromArgb(13, 255, 255, 255) },
                                                        { 1, Color.FromArgb(13, 255, 255, 255) }
                                                    }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                       OuterRadius = new PercentageOrPixel(0, true),
                                    }
                                   
                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = 0,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '50px' ,color: 'Black'",
                           BorderWidth = 0

                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,

                   Max = 750,


                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,

                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 20,

                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 5,
                   TickColor = ColorTranslator.FromHtml("#80a93b"),
                   Labels = new YAxisLabels
                   {

                       Step = 3,
                       Distance = -20,
                       Style = "color: '#fff'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666'",
                       Align = AxisTitleAligns.High,
                       Margin = -10

                   },
                   PlotBands = new[]
                            {

                                new YAxisPlotBands 
                                {
                                  From = 0, To = 750,
                                    Color = ColorTranslator.FromHtml("#80a93b"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                
                            },
               })
               .SetSeries(new Series
               {
                   Name = "New",
                   Data = new Data(new object[] { DataValue }),
                   YAxis = "0",
                   PlotOptionsGauge = new PlotOptionsGauge
                   {
                       Dial = new PlotOptionsGaugeDial
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#55BF3B" }, { 1, "#55BF3B" } }
                           })
                       },
                       Pivot = new PlotOptionsGaugePivot
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#55BF3B" }, { 1, "#55BF3B" } }
                           })
                       }
                   }
               });

            return chart;

        }
        
        public static Highcharts GetPurplWT(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugepprWT")
               .InitChart(new Chart
               {
                   Width = 200,
                   Height = 200,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
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

               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title
               {
                   Text = "",
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom

               })
               .SetPane(new Pane
               {
                   StartAngle = -120,
                   EndAngle = 120,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 400 },
                                                Stops = new object[,]
                                                    {
                                                        { 0, Color.FromArgb(13, 255, 255, 255) },
                                                        { 1, Color.FromArgb(13, 255, 255, 255) }
                                                    }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                       OuterRadius = new PercentageOrPixel(0, true),
                                    }
                                   

                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = 0,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '50px' ,color: '#fff'",
                           BorderWidth = 0

                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 750,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 20,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 5,
                   TickColor = ColorTranslator.FromHtml("#007acc"),
                   Labels = new YAxisLabels
                   {
                       Step = 3,
                       Distance = -20
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands 
                                {
                                  From = 0, To = 750,
                                    Color = ColorTranslator.FromHtml("#5e0090"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                
                            },
               })
               .SetSeries(new Series
               {

                   Name = "New",
                   Data = new Data(new object[] { DataValue }),

                   YAxis = "0",
                   PlotOptionsGauge = new PlotOptionsGauge
                   {
                       Dial = new PlotOptionsGaugeDial
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },

                               Stops = new object[,] { { 0, "#5fc0fe" }, { 1, "#5fc0fe" } }
                           })
                       },
                       Pivot = new PlotOptionsGaugePivot
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#5fc0fe" }, { 1, "#5fc0fe" } }

                           })
                       }
                   }
               });
            return chart;


        }
       
        public static Highcharts GetPurplSYS(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugepprSYS")
               .InitChart(new Chart
               {
                   Width = 200,
                   Height = 200,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
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

               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title
               {
                   Text = "",
                   Align = HorizontalAligns.Center,
                   VerticalAlign = VerticalAligns.Bottom

               })
               .SetPane(new Pane
               {
                   StartAngle = -120,
                   EndAngle = 120,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 400 },
                                                Stops = new object[,]
                                                    {
                                                        { 0, Color.FromArgb(13, 255, 255, 255) },
                                                        { 1, Color.FromArgb(13, 255, 255, 255) }
                                                    }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                       OuterRadius = new PercentageOrPixel(0, true),
                                    }
                                   
                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = 0,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '50px' ,color: '#fff'",
                           BorderWidth = 0

                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 750,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 20,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 5,
                   TickColor = ColorTranslator.FromHtml("#007acc"),
                   Labels = new YAxisLabels
                   {
                       Step = 3,
                       Distance = -20
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands 
                                {
                                  From = 0, To = 750,
                                    Color = ColorTranslator.FromHtml("#5e0090"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                
                            },
               })
               .SetSeries(new Series
               {
                   Name = "New",
                   Data = new Data(new object[] { DataValue }),
                   YAxis = "0",
                   PlotOptionsGauge = new PlotOptionsGauge
                   {
                       Dial = new PlotOptionsGaugeDial
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#5fc0fe" }, { 1, "#5fc0fe" } }
                           })
                       },
                       Pivot = new PlotOptionsGaugePivot
                       {
                           BackgroundColor = new BackColorOrGradient(new Gradient
                           {
                               LinearGradient = new[] { 0, 0, 0, 1 },
                               Stops = new object[,] { { 0, "#5fc0fe" }, { 1, "#5fc0fe" } }
                           })
                       }
                   }
               });

            return chart;


        }
      
    }
}