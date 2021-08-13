using SharedDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    [AutoToString]
    public partial class Foo
    {
        public int Property1 { get; set; } = 1;
        public int Property2 { get; set; } = 2;
        public int Property3 { get; set; } = 3;
        public int Property4 { get; set; } = 4;
        public Foo()
        {
        }
    }
}
