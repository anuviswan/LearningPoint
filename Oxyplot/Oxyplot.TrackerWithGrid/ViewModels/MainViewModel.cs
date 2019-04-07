using Caliburn.Micro;
using Oxyplot.TrackerWithGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oxyplot.TrackerWithGrid;
using OxyPlot;

namespace Oxyplot.TrackerWithGrid.ViewModels
{
    public class MainViewModel:Screen
    {
        public IObservableCollection<Fruit> Fruits { get; set; } = new BindableCollection<Fruit>();

        public MainViewModel()
        {
            GenerateFruitCollection();
            NotifyOfPropertyChange(nameof(Fruits));
        }

        public PlotModel DataPlotModel { get; set; }

        private void GenerateFruitCollection()
        {
            var fruitFactory = IoC.Get<FruitFactory>();
            Fruits = new BindableCollection<Fruit>(fruitFactory.Generate());
        }
    }
}
