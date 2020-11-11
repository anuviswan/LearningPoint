using System;
using System.Collections.Generic;
using System.Text;

namespace NullHandling
{
    public class Foo
    {
        public string Bar { get; set; }
    }
    public class NullArgumentValidation
    {
        public bool DemoUsingExplicitValidation(Foo foo)
        {
            if(foo is null)
            {
                throw new ArgumentNullException(nameof(foo));
            }

            return true;
        }

        //public bool DemoUsingImplicitValidation(Foo foo!!) => true;
    }
}
