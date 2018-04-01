using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MexicanGreenWavePizza : IPizza
    {
        public string Description => "Mexican Green Wave Pizza";
        public int CalculatePrice() => 105;
    }
}
