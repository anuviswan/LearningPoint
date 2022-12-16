using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticVirtualInterfaceMembers
{
    public interface IFibGen<T> : where T is IFibGen<T>
    {
        static abstract operator ++(T other);
    }

    public class Fibonacii : IFibGen<Fibonacii>
    {
        public static operator ++(Fibonacii other) { }
    }
}
