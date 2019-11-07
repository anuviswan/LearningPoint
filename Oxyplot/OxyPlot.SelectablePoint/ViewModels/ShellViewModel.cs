using Caliburn.Micro;
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
            var series = new LineSeries
            {
                MarkerFill = OxyColors.LightBlue,
                MarkerType = MarkerType.Circle,
                LineStyle = LineStyle.Solid,
                Color = OxyColors.Blue,
                ItemsSource = collection,
                MarkerSize = 5
            };

            series.MouseDown += Series_MouseDown;

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

        private void Series_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            var nearestPoint = (sender as OxyPlot.Series.Series).GetNearestPoint(e.Position, false);
            var selectedSeries = new LineSeries
            {
                MarkerSize = 5,
                MarkerFill = OxyColors.Red,
                MarkerType = MarkerType.Circle
            };

            selectedSeries.Points.Add(nearestPoint.DataPoint);
            GraphModel.Series.Add(selectedSeries);
            GraphModel.InvalidatePlot(true);
        }

        public PlotModel GraphModel { get; set; }
    }
}
