using Caliburn.Micro;
using Oxyplot.TrackerWithGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oxyplot.TrackerWithGrid;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Newtonsoft.Json;
using Oxyplot.TrackerWithGrid.OxyplotExtensions;

namespace Oxyplot.TrackerWithGrid.ViewModels
{
    public class MainViewModel:Screen
    {
        public IObservableCollection<Fruit> Fruits { get; set; } = new BindableCollection<Fruit>();

        public MainViewModel()
        {
            var fruitCollection = GenerateFruitCollection();
            Fruits = new BindableCollection<Fruit>(fruitCollection);
            NotifyOfPropertyChange(nameof(Fruits));
            CreatePlotModel(Fruits);
        }

        public PlotModel DataPlotModel { get; set; } = new PlotModel();

        private IEnumerable<Fruit> GenerateFruitCollection()
        {
            var fruitFactory = IoC.Get<FruitFactory>();
            return fruitFactory.Generate();
            
        }

        private void CreatePlotModel(IEnumerable<Fruit> totalSalesDetails)
        {
            var tmp = new PlotModel { Title = "Simple example", Subtitle = "using OxyPlot" };

            tmp.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Bottom,
                IsAxisVisible = false,
                IsPanEnabled = true,
                IsZoomEnabled = true
            });

            tmp.Axes.Add(new LinearAxis()
            {
                Position = AxisPosition.Left,
                IsAxisVisible = false,
                IsPanEnabled = true,
                IsZoomEnabled = true
            });

            var series1 = new LineSeries { Title = "Series 1", MarkerType = MarkerType.Circle };
            series1.Points.Add(new DataPoint(0, 0));
            series1.Points.Add(new DataPoint(10, 18));
            series1.Points.Add(new DataPoint(20, 12));
            series1.Points.Add(new DataPoint(30, 8));
            series1.Points.Add(new DataPoint(40, 15));

            tmp.Series.Add(series1);

            DataPlotModel = tmp;
            DataPlotModel.InvalidatePlot(true);
            //DataPlotModel.Series.Add(lineSeries);
        }
    }
}

