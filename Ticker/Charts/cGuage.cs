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
        public static Highcharts GetGuage()
        {
            Highcharts chart = new Highcharts("chart")
               .InitChart(new Chart
               {
                   Width = 500,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
                   PlotShadow = false
               })
               .SetTitle(new Title { Text = "Speedometer" })
               .SetPane(new Pane
               {
                   StartAngle = -150,
                   EndAngle = 150,
                   Background = new[]
                            {
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 1 },
                                                Stops = new object[,] { { 0, "#FFF" }, { 1, "#333" } }
                                            }),
                                        BorderWidth = new PercentageOrPixel(0),
                                        OuterRadius = new PercentageOrPixel(109, true)
                                    },
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(new Gradient
                                            {
                                                LinearGradient = new[] { 0, 0, 0, 1 },
                                                Stops = new object[,] { { 0, "#333" }, { 1, "#FFF" } }
                                            }),
                                        BorderWidth = new PercentageOrPixel(1),
                                        OuterRadius = new PercentageOrPixel(107, true)
                                    },
                                new BackgroundObject(),
                                new BackgroundObject
                                    {
                                        BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#DDD")),
                                        BorderWidth = new PercentageOrPixel(0),
                                        OuterRadius = new PercentageOrPixel(105, true),
                                        InnerRadius = new PercentageOrPixel(103, true)
                                    }
                            }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 500,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 1,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Outside,
                   MinorTickColor = ColorTranslator.FromHtml("#666"),
                   TickPixelInterval = 30,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 10,
                   TickColor = ColorTranslator.FromHtml("#666"),
                   Labels = new YAxisLabels
                   {
                       Step = 5,
                       //Rotation = "auto"
                   },
                   Title = new YAxisTitle { Text = "km/h" },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands { From = 0, To = 500, Color = ColorTranslator.FromHtml("#55BF3B") },
                                //new YAxisPlotBands { From = 120, To = 160, Color = ColorTranslator.FromHtml("#DDDF0D") },
                                //new YAxisPlotBands { From = 160, To = 200, Color = ColorTranslator.FromHtml("#DF5353") }
                            }
               })
               .SetSeries(new Series
               {
                   Name = "Speed",
                   Data = new Data(new object[] { 80 }),
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
                       Pivot=new PlotOptionsGaugePivot
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
    }
}