using BarAssembly;
using System;
using System.Net.Cache;

namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
            foo.Print(new { Name = "Jia Anu", Age = 4 });

            var bar= new Bar();
            bar.Print(new { Name = "Jia Anu", Age = 4 });
            bar.Print(new User{ Name = "Jia Anu", Age = 4 });
            Console.ReadLine();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Foo
    {
        public void Print<T>(T data)
        {
            Console.WriteLine($"Type : {typeof(T)}");
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                Console.WriteLine($"{property.Name} = { property.GetValue(data)}");
            }
        }
    }
}
