﻿using DotNet.Highcharts;
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
        /// <summary>
        /// This Method Is for Guage of NewOrder.
        /// </summary>
        /// <param name="DataValue">
        /// Int neworder quantity pass as parameter.
        /// </param>
        /// <returns>
        /// Return Chart.
        /// </returns>
        public static Highcharts GetNewShipmentGuage( int DataValue )
        {
            Highcharts chart = new Highcharts("chartgauge")
               .InitChart(new Chart
               {
                   Width = 500,
                   Height = 230,
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

               }).SetCredits(new Credits
               {
                   Enabled = false,
                   Href = "http://www.kraususa.com/",
                   Text = "kraus USA Inc."
               }).SetExporting(new Exporting { Enabled = false })
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
                           Y = 10,
                           X = 0,
                           Style = "fontWeight:'bold',fontSize: '45px' ,color: '#007acc',fontFamily: 'Arial'",
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
                   TickLength = 3,
                   TickColor = ColorTranslator.FromHtml("#007acc"),
                   Labels = new YAxisLabels
                   {
                       Enabled=false,
                       Step = 3,
                       Distance = -15,
                       Style = "color: 'Gray' ,fontSize: '8px',fontFamily: 'Arial'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666',fontFamily: 'Arial'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                 new YAxisPlotBands 
                                {
                                    From = 0, To = 200,
                                    Color = ColorTranslator.FromHtml("#70C133"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                new YAxisPlotBands
                                {
                                    From = 200, To = 400,
                                    Color = ColorTranslator.FromHtml("#FF8000"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                               new YAxisPlotBands
                                {
                                    From = 400, To = 750,
                                    Color = ColorTranslator.FromHtml("#DF0101"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                }
                                
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

        /// <summary>
        /// This Method is for Guage for NYWT Process.
        /// </summary>
        /// <param name="DataValue"></param>
        /// <returns></returns>
        public static Highcharts GetGreenSYS(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugeGreenSYS")
               .InitChart(new Chart
               {
                   Width = 250,
                   Height = 170,
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

               }).SetCredits(new Credits
               {
                   Enabled = false,
                   Href = "http://www.kraususa.com/",
                   Text = "kraus USA Inc."
               }).SetExporting(new Exporting { Enabled = false })
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
                           Style = "fontWeight:'bold',fontSize: '40px' ,color: '#007acc',fontFamily: 'Arial'",
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
                   TickWidth = 1,
                   TickPosition = TickPositions.Inside,
                   TickLength = 3,
                   TickColor = ColorTranslator.FromHtml("#80a93b"),
                   Labels = new YAxisLabels
                   {
                       Enabled=false,
                       Distance = -15,
                       Style = "color: 'Gray' ,fontSize: '8px',fontFamily: 'Arial'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666',fontFamily: 'Arial'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands 
                                {
                                    From = 0, To = 200,
                                    Color = ColorTranslator.FromHtml("#70C133"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                new YAxisPlotBands
                                {
                                    From = 200, To = 400,
                                    Color = ColorTranslator.FromHtml("#FF8000"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                               new YAxisPlotBands
                                {
                                    From = 400, To = 750,
                                    Color = ColorTranslator.FromHtml("#DF0101"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                }
                                
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
      
        /// <summary>
        /// This Method is for Guage for NYWH Process.
        /// </summary>
        /// <param name="DataValue"></param>
        /// <returns></returns>
        public static Highcharts GetGreenWT(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugeGreenWT")
               .InitChart(new Chart
               {
                   Width = 250,
                   Height = 170,
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

               }).SetCredits(new Credits
               {
                   Enabled = false,
                   Href = "http://www.kraususa.com/",
                   Text = "kraus USA Inc."
               }).SetExporting(new Exporting { Enabled = false })
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
                           Style = "fontWeight:'bold',fontSize: '40px' ,color: '#007acc',fontFamily: 'Arial'",
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
                   TickLength = 3,
                   TickColor = ColorTranslator.FromHtml("#80a93b"),
                   Labels = new YAxisLabels
                   {
                       Enabled=false,
                       Step = 3,
                       Distance = -15,
                       Style = "color: 'Gray' ,fontSize: '8px'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#80a93b',fontFamily: 'Arial'",
                       Align = AxisTitleAligns.High,
                       Margin = -10

                   },
                   PlotBands = new[]
                            {

                               new YAxisPlotBands 
                                {
                                    From = 0, To = 200,
                                    Color = ColorTranslator.FromHtml("#70C133"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                new YAxisPlotBands
                                {
                                    From = 200, To = 400,
                                    Color = ColorTranslator.FromHtml("#FF8000"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                               new YAxisPlotBands
                                {
                                    From = 400, To = 750,
                                    Color = ColorTranslator.FromHtml("#DF0101"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                }
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
        
        /// <summary>
        /// This Method is for Guage of NYWH Shipped.
        /// </summary>
        /// <param name="DataValue"></param>
        /// <returns></returns>
        public static Highcharts GetPurplWT(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugepprWT")
               .InitChart(new Chart
               {
                   Width = 250,
                   Height = 170,
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

               }).SetCredits(new Credits
               {
                   Enabled = false,
                   Href = "http://www.kraususa.com/",
                   Text = "kraus USA Inc."
               }).SetExporting(new Exporting { Enabled = false })
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
                           Style = "fontWeight:'bold',fontSize: '40px' ,color: '#007acc',fontFamily: 'Arial'",
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
                   TickLength = 3,
                   TickColor = ColorTranslator.FromHtml("#5e0090"),
                   Labels = new YAxisLabels
                   {

                       Enabled = false,
                       Step = 3,
                       Distance = -15,
                       Style = "color: 'Gray' ,fontSize: '8px',fontFamily: 'Arial'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666',fontFamily: 'Arial'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                 new YAxisPlotBands 
                                {
                                    From = 0, To = 200,
                                    Color = ColorTranslator.FromHtml("#DF0101"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                new YAxisPlotBands
                                {
                                    From = 200, To = 400,
                                    Color = ColorTranslator.FromHtml("#FF8000"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                               new YAxisPlotBands
                                {
                                    From = 400, To = 750,
                                    Color = ColorTranslator.FromHtml("#70C133"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                }
                                
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
       
        /// <summary>
        /// This Method is for Gauge of NYWT Shipped.
        /// </summary>
        /// <param name="DataValue"></param>
        /// <returns></returns>
        public static Highcharts GetPurplSYS(int DataValue)
        {
            Highcharts chart = new Highcharts("chartgaugepprSYS")
               .InitChart(new Chart
               {
                   Width = 250,
                   Height = 170,
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

               }).SetCredits(new Credits
               {
                   Enabled = false,
                   Href = "http://www.kraususa.com/",
                   Text = "kraus USA Inc."
               }).SetExporting(new Exporting { Enabled = false })
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
                           Style = "fontWeight:'bold',fontSize: '40px' ,color: '#007acc',fontFamily: 'Arial'",
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
                   TickLength = 3,
                   TickColor = ColorTranslator.FromHtml("#5e0090"),
                   Labels = new YAxisLabels
                   {
                       Enabled=false,
                       Step = 3,
                       Distance = -15,
                       Style = "color: 'Gray' ,fontSize: '8px',fontFamily: 'Arial'"
                   },
                   Title = new YAxisTitle
                   {
                       Text = "",
                       Style = "fontSize: '30px' ,color: '#666',fontFamily: 'Arial'",
                       Align = AxisTitleAligns.High,
                       Margin = -10
                   },
                   PlotBands = new[]
                            {
                                  new YAxisPlotBands 
                                {
                                    From = 0, To = 200,
                                    Color = ColorTranslator.FromHtml("#DF0101"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                                new YAxisPlotBands
                                {
                                    From = 200, To = 400,
                                    Color = ColorTranslator.FromHtml("#FF8000"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                },
                               new YAxisPlotBands
                                {
                                    From = 400, To = 750,
                                    Color = ColorTranslator.FromHtml("#70C133"), 
                                    Thickness =new PercentageOrPixel (200,true), 
                                    InnerRadius = new PercentageOrPixel(130, true)
                                }
                                
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
      
    }
}