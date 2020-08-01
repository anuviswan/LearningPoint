using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxyplot.FourQuadrant.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            var model = new PlotModel { Title = "Example Tracker" };
            var points = new List<DataPoint>
                              {
                                 // new DataPoint(0, 4),
                                  new DataPoint(-10, -13),
                                  new DataPoint(20, 15),
                                  new DataPoint(30, 16),
                                  new DataPoint(40, 12),
                                  new DataPoint(50, 12)
                              };
            var seriesVisible = new OxyPlot.Series.LineSeries
            {
                Color = OxyColors.Blue,
                MarkerFill = OxyColors.Red,
                ItemsSource = points,
                TrackerFormatString = "X={2},\nY={4},\nAdditionalInfo={Description}",
                MarkerType = MarkerType.Circle,
                MarkerSize = 5

            };
            var XAxis = new LinearAxis
            {
                Key = "xAxisKeyPositive",
                Position = AxisPosition.Top,
                PositionTier = 0,
                AxislineStyle = LineStyle.Solid,
                Minimum = 0,
                StartPosition = 0.5,
                EndPosition = 1,
                PositionAtZeroCrossing = true,
                AbsoluteMinimum = 0,
                Title = "X1",

            };
            model.Axes.Add(XAxis);

            var XAxis2 = new LinearAxis
            {
                Key = "xAxisKeyNegative",
                Position = AxisPosition.Top,
                PositionTier = 0,
                AxislineStyle = LineStyle.Solid,
                Minimum = 0,
                AxislineColor = OxyColors.Gold,
                StartPosition = 0.5,
                EndPosition = 0,
                PositionAtZeroCrossing = true,
                IsAxisVisible = true,
                AbsoluteMinimum = 0,
                Title = "X",

            };
            model.Axes.Add(XAxis2);
            var YAxis = new LinearAxis
            {
                Key = "yAxisKeyPositive",
                Position = AxisPosition.Left,
                AxislineStyle = LineStyle.Solid,
                Minimum = 0,
                AxislineColor = OxyColors.Green,
                PositionTier = 0,
                StartPosition = 0.5,
                EndPosition = 1,
                PositionAtZeroCrossing = true,
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 1000,
                Title = "Y",

            };
            model.Axes.Add(YAxis);
            var YAxis2 = new LinearAxis
            {
                Key = "_yAxisKeyNegative",
                Position = AxisPosition.Right,
                AxislineStyle = LineStyle.Solid,
                Minimum = 0,
                AxislineColor = OxyColors.Violet,
                PositionTier = 0,
                StartPosition = 0.5,
                EndPosition = 0,
                PositionAtZeroCrossing = true,
                AbsoluteMinimum = 0,

            };
            model.Axes.Add(YAxis2);
            model.Series.Add(seriesVisible);
            MyModel = model;


            MyModel.InvalidatePlot(true);
        }

        public PlotModel MyModel { get; set; }
    }
}
