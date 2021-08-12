using SharedDemo;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Hello.World.Hi();
            Console.WriteLine("Hello World!");
        }
    }

    [AutoToString]
    public partial class Foo
    {
        private int _sm;
    }
}
