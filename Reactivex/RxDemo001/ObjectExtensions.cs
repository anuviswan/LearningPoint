using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxDemo001
{
    public static class ObjectExtensions
    {
        public static void Execute<T>(this T source,Action action)
        {
            action();
        }
    }
}
