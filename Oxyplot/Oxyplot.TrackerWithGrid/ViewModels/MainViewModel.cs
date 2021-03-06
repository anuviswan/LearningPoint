﻿using Caliburn.Micro;
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
            var salesGrouping = totalSalesDetails.GroupBy(x => x.Date);
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Items Sold"
            };
            var xAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = DateTimeAxis.ToDouble(salesGrouping.Min(x => x.Key)),
                Maximum = DateTimeAxis.ToDouble(salesGrouping.Max(x => x.Key)),
                Title = "Date"
            };


            DataPlotModel.Axes.Add(yAxis);
            DataPlotModel.Axes.Add(xAxis);

            var lineSeries = new LineSeries
            {
                MarkerFill = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
            };

            lineSeries.ItemsSource = salesGrouping.Select(x => new ExtendedDataPoint
            {
                Date = x.Key.Date,
                ItemsSold = x.ToList()
            });
            DataPlotModel.Series.Add(lineSeries);
        }
    }
}

