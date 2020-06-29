using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticLocalFunctions
{
    public class DemoClass
    {
        public void Foo()
        {
            int internalValue = 20;

            void Bar()
            {
                Console.WriteLine("Do Something");
                internalValue++; // This would throw compile error
            }
            Bar();
        }
    }
}
