using Caliburn.Micro;
using OxyPlot.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.TrackerDemo.ViewModels
{
    public class ShellViewModel:Screen
    {
        public ShellViewModel()
        {
            var model = new PlotModel { Title = "Example Tracker" };
            var points  = new List<CustomDataPoint>
                              {
                                  new CustomDataPoint(0, 4,"point 1"),
                                  new CustomDataPoint(10, 13,"point 2"),
                                  new CustomDataPoint(20, 15,"point 3"),
                                  new CustomDataPoint(30, 16,"point 4"),
                                  new CustomDataPoint(40, 12,"point 5"),
                                  new CustomDataPoint(50, 12,"point 6")
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
            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = Axes.AxisPosition.Bottom
            });

            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = Axes.AxisPosition.Left
            });
            model.Series.Add(seriesVisible);
            MyModel = model;
            

            CustomPlotController = new PlotController();
            CustomPlotController.UnbindAll();
            CustomPlotController.BindTouchDown(PlotCommands.PointsOnlyTrackTouch);
            MyModel.InvalidatePlot(true);
        }

        public PlotModel MyModel { get; set; }

        public PlotController CustomPlotController { get; set; }
    }
}
