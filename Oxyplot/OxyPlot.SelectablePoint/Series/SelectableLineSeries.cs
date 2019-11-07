using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.SelectablePoint.Series
{
    public class SelectableLineSeries:LineSeries
    {
        public bool IsDataPointSelectable { get; set; }
        public SelectableLineSeries()
        {
            MouseDown += SelectableLineSeries_MouseDown;
        }

        private void SelectableLineSeries_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            if (IsDataPointSelectable)
            {
                var activeSeries = (sender as OxyPlot.Series.Series);
                var nearestPoint = activeSeries.GetNearestPoint(e.Position, false);
                var selectedSeries = new LineSeries
                {
                    MarkerSize = 5,
                    MarkerFill = OxyColors.Red,
                    MarkerType = MarkerType.Circle
                };

                selectedSeries.Points.Add(nearestPoint.DataPoint);
                activeSeries.PlotModel.Series.Add(selectedSeries);
                activeSeries.PlotModel.InvalidatePlot(true);
            }
        }

    }
}
