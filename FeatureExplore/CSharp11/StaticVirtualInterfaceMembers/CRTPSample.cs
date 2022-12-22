using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticVirtualInterfaceMembers
{
    internal interface IFruit<TDerieved>
    {
        static abstract TDerieved CreateInstance();
    }

    internal class Apple : IFruit<Apple>
    {
        public static Apple CreateInstance() => new Apple();

        public void SayHello() => Console.WriteLine("Hello");
    }

    internal class Orange : IFruit<int>
    {
        public static int CreateInstance() => 0;
    }
}
