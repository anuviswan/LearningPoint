using Caliburn.Micro;
using Oxyplot.TrackerStayOpen.CustomTrackerManipulator;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxyplot.TrackerStayOpen.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ShellViewModel()
        {
            var model = new PlotModel { Title = "Example Tracker" };
            var points = new List<DataPoint>
                              {
                                  new DataPoint(0, 4),
                                  new DataPoint(10, 13),
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
            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom
            });

            model.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left
            });
            model.Series.Add(seriesVisible);
            MyModel = model;


            var customController = new PlotController();
            customController.UnbindAll();
            customController.BindMouseDown(OxyMouseButton.Left, new DelegatePlotCommand<OxyMouseDownEventArgs>((view, controller, args) =>
                controller.AddMouseManipulator(view, new StaysOpenTrackerManipulator(view), args)));
            CustomPlotController = customController;
            MyModel.InvalidatePlot(true);
        }

        public PlotModel MyModel { get; set; }

        public PlotController CustomPlotController { get; set; }
    }
    
}
