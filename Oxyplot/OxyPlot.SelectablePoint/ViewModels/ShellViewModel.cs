using Caliburn.Micro;
using OxyPlot.SelectablePoint.Series;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                MarkerFill = OxyColors.LightBlue,
                MarkerType = MarkerType.Circle,
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
