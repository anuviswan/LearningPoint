using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TooltipOverlayBug.ViewModels
{
    public class ShellViewModel
    {
        public ShellViewModel()
        {
            var dataPoints = Enumerable.Range(1, 10).Select(x => new DataPoint(x, x * 10));
            GraphModel = new PlotModel();
            GraphModel.Title = "Sample Test";
            GraphModel.Series.Add(new LineSeries
            {
                ItemsSource = dataPoints,
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Square,
                TrackerFormatString = $"{{ 0 }}\n\n\n\n\n\n\n{{ 1 }}:  {{2:0.###}}\n\n\n\n\n\n\n\n{{3}}: {{4:0.###}}"
            }); ;
            GraphModel.InvalidatePlot(true);
        }

        public PlotModel GraphModel { get; set; }
    }
}
