using BarAssembly;
using System;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: InternalsVisibleTo("BarAssembly")]
namespace AnonymousTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new
            {
                UserName = "Anu Viswan",
                Age = 36,
                JoiningDate = new DateTime(2020,10,10),
            };

            var anotherInstance = new
            {
                UserName = "Anu Viswan",
                Age = 36,
                JoiningDate = new DateTime(2020, 10, 10),
            };

            Console.WriteLine($"user & anotherInstance - Equality :{user.Equals(anotherInstance)}"); // True

            Console.WriteLine($"user & anotherInstance - Type Equality :{user.GetType() == anotherInstance.GetType()}"); // True

            var differentInstance = new
            {
                UserName = "Anu Viswan",
                JoiningDate = new DateTime(2020, 10, 10),
                Age = 36,
            };

            Console.WriteLine($"user & differentInstance - Equality :{user.GetType() == differentInstance.GetType()}"); // False


            // user.Age = 37;  // This line would throw error as anonymous types has read-only properties

            user = new      // Recreate object for reassigning properties
            {
                UserName = user.UserName,
                Age = 37,
                JoiningDate = user.JoiningDate,
            };

            Console.WriteLine($"Anonymous Type is derieved from Object : {user is object}");

            var foo = new Foo();
            foo.Print(user);
            foo.Print((object)user);

            var bar = new Bar();
            bar.Print(user);

        }
    }

   
    public class Foo
    {
        public void Print(object data)
        {
            var typeSchema = new { UserName = string.Empty, Age = default(int), JoiningDate = default(DateTime) };
            var castInstance = Cast(typeSchema, data);
        }

        private static T Cast<T>(T typeHolder, Object x) where T : class
        {
            return (T)x;
        }
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
