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
            Highcharts chart = new Highcharts("chartgauge")
               .InitChart(new Chart
               {
                   Width = 200,
                   Height = 200,
                   Type = ChartTypes.Gauge,
                   PlotBackgroundColor = null,
                   PlotBackgroundImage = null,
                   PlotBorderWidth = 0,
                   PlotShadow = false
               }).SetCredits(new Credits { Enabled = false })
               .SetTitle(new Title { Text = "" })
               .SetPane(new Pane
               {
                   StartAngle = -100,
                   EndAngle = 100,
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
                                       OuterRadius = new PercentageOrPixel(109, true)
                                    },
                            }
               }).SetPlotOptions(new PlotOptions
               {
                   Gauge = new PlotOptionsGauge
                   {
                       DataLabels = new PlotOptionsGaugeDataLabels
                       {
                           Y = -25,
                           Style = "fontWeight:'bold',fontSize: '60px' ,color: '#007acc'",
                           BorderWidth=0
                    
                       }
                   }
               })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Max = 500,

                   //MinorTickInterval = "auto",
                   MinorTickWidth = 0,
                   MinorTickLength = 10,
                   MinorTickPosition = TickPositions.Inside,
                   MinorTickColor = ColorTranslator.FromHtml("#fff"),
                   TickPixelInterval = 35,
                   TickWidth = 2,
                   TickPosition = TickPositions.Inside,
                   TickLength = 30,
                   TickColor = ColorTranslator.FromHtml("#007acc"),
                   Labels = new YAxisLabels
                   {
                       Step = 2,
                       Distance = 10
                   },
                   Title = new YAxisTitle { Text = "" },
                   PlotBands = new[]
                            {
                                new YAxisPlotBands { From = 0, To = 500, Color = ColorTranslator.FromHtml("#007acc"), Thickness =new PercentageOrPixel (30,true)},
                                
                            },
               })
               .SetSeries(new Series
               {
                   Name = "New",
                   Data = new Data(new object[] { 80 }),


               });

            return chart;
       
        }
    }
}