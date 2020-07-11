using System;

namespace CSharp9.InitProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo
            {
                FirstName = "Anu",
                LastName = "Viswan"
            };
        }
    }

    public class Foo
    {
        public string FirstName { get; set; }
        public string LastName { get; init; }
    }

}

namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}