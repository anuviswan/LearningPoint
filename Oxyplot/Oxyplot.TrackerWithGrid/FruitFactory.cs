using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oxyplot.TrackerWithGrid.Models;

namespace Oxyplot.TrackerWithGrid
{
    public class FruitFactory
    {
        private enum eFruits
        {
            Apple,
            Banana,
            Mango,
            Jackfruit
        }
        public IEnumerable<Fruit> Generate()
        {
            var random = new Random();
            return Enumerable.Range(1, 10)
                            .SelectMany(x => 
                            {
                                return ((eFruits[])Enum.GetValues(typeof(eFruits))).Select(f =>
                                new Fruit
                                {
                                    Name = f.ToString(),
                                    ItemsSold = random.Next(0, 100),
                                    Date = DateTime.Now.AddDays(x)
                                });
                            });
        }
    }
}
