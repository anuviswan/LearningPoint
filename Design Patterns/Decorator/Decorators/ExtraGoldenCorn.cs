using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    public class ExtraGoldenCorn : IPizza
    {
        private IPizza _PizzaInstance;
        public ExtraGoldenCorn(IPizza pizza) => _PizzaInstance = pizza;
        public string Description => $"{_PizzaInstance.Description} with Extra Golden Corn";
        public int CalculatePrice() => _PizzaInstance.CalculatePrice() + 5;
    }
}
