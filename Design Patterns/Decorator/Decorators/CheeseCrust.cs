using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorators
{
    class CheeseCrust : IPizza
    {
        private IPizza _PizzaInstance;
        public CheeseCrust(IPizza pizza) => _PizzaInstance = pizza;

        public string Description => $"{_PizzaInstance.Description} With Cheese Crust";
        public int CalculatePrice() => _PizzaInstance.CalculatePrice() + 7;
    }
}
