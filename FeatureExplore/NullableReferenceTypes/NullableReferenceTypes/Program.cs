#define EnableWarnings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable
namespace NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();

            foo.CreateBarInstance(new Bar(2));
            Console.WriteLine(foo.Bar.Id);
            foo.CreateBarInstance(new Bar(3));
            Console.WriteLine(foo.Bar.Id);
            Console.ReadLine();

        }

    }
    public class Foo
    {
        public Foo()
        {
        }

#if EnableWarnings
        public Bar? Bar { get; set; }  // Nullable Reference Type
        public Bar AnotherBar { get; set; } = null!; // Non-nullable Reference Type, with Null-Forgiving Operator

#else
        public Bar Bar { get; set; }
        public Bar AnotherBar { get; set; }
#endif


        public void CreateBarInstance(Bar instance)
        {
            Bar ??= instance;
        }
    }

    public class Bar
    {
        public Bar(int id) => Id = id;
        public int Id { get; set; } 
    }
}
