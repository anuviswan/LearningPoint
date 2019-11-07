using Caliburn.Micro;
using OxyPlot.SelectablePoint.Series;
using System;
using System.Linq;

namespace OxyPlot.SelectablePoint.ViewModels
{
    public class ShellViewModel:Screen
    {
        public ShellViewModel()
        {
            var random = new Random();
            var collection = Enumerable.Range(1, 5).Select(x => new DataPoint(x, random.Next(100, 400))).ToList();
            var series = new SelectableLineSeries
            {
                IsDataPointSelectable = true,
                MarkerFill = OxyColors.Blue,
                MarkerType = MarkerType.Square,
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Blue,
                ItemsSource = collection,
                MarkerSize = 5
            };

            GraphModel = new PlotModel();

            GraphModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = Axes.AxisPosition.Bottom
            });

            GraphModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = Axes.AxisPosition.Left
            });

            GraphModel.Series.Add(series);
            GraphModel.InvalidatePlot(true);
        }

        
        public PlotModel GraphModel { get; set; }
    }
}
