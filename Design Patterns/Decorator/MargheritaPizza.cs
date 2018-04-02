using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MargheritaPizza : IPizza
    {
        public string Description => "Margherita Pizza";
        public int CalculatePrice() => 100;
    }
}
