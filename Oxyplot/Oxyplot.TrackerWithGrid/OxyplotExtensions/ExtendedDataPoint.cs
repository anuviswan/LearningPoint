using Newtonsoft.Json;
using Oxyplot.TrackerWithGrid.Models;
using OxyPlot;
using OxyPlot.Axes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oxyplot.TrackerWithGrid.OxyplotExtensions
{
    public class ExtendedDataPoint : IDataPointProvider
    {
        public DateTime Date { get; set; }
        public IEnumerable<Fruit> ItemsSold { get; set; }

        public string SalesDetails => JsonConvert.SerializeObject(ItemsSold);

        public DataPoint GetDataPoint()
        {
            return new DataPoint(DateTimeAxis.ToDouble(Date), ItemsSold.Sum(x=>x.ItemsSold));
        }
    }
}
