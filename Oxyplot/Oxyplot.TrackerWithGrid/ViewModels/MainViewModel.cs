using Caliburn.Micro;
using Oxyplot.TrackerWithGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oxyplot.TrackerWithGrid;
namespace Oxyplot.TrackerWithGrid.ViewModels
{
    public class MainViewModel:Screen
    {
        public IObservableCollection<Fruit> Fruits = new BindableCollection<Fruit>();

        public MainViewModel()
        {
            GenerateFruitCollection();
            NotifyOfPropertyChange(nameof(Fruits));
        }

        private void GenerateFruitCollection()
        {
            var fruitFactory = IoC.Get<FruitFactory>();
            Fruits = new BindableCollection<Fruit>(fruitFactory.Generate());
        }
    }
}
