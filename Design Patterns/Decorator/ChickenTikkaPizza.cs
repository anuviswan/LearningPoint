using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class ChickenTikkaPizza : IPizza
    {
        public string Description => "Chicken Tikka Pizza";
        public int CalculatePrice() => 115;
    }
}
