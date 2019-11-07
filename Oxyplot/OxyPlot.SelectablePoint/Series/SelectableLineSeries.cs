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

        public DataPoint CurrentSelection { get; set; }

        public OxyColor SelectedDataPointColor { get; set; } = OxyColors.Red;
        public SelectableLineSeries()
        {
            MouseDown += SelectableLineSeries_MouseDown;
        }

        private void SelectableLineSeries_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            if (IsDataPointSelectable)
            {
                var activeSeries = (sender as OxyPlot.Series.Series);
                var currentPlotModel = activeSeries.PlotModel;
                var nearestPoint = activeSeries.GetNearestPoint(e.Position, false);
                CurrentSelection = nearestPoint.DataPoint;

                currentPlotModel = ClearCurrentSelection(currentPlotModel);

                var selectedSeries = new SelectedLineSeries
                {
                    MarkerSize = MarkerSize + 2,
                    MarkerFill = SelectedDataPointColor,
                    MarkerType = MarkerType
                };

                selectedSeries.Points.Add(CurrentSelection);
                currentPlotModel.Series.Add(selectedSeries);
                currentPlotModel.InvalidatePlot(true);
            }
        }

        private PlotModel ClearCurrentSelection(PlotModel plotModel)
        {
            while(plotModel.Series.Any(x=> x is SelectedLineSeries))
            {
                plotModel.Series.Remove(plotModel.Series.First(x=> x is SelectedLineSeries));
            }
            return plotModel;
        }

    }
}
