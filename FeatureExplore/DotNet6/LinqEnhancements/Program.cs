using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqEnhancements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is demo code for enhancements in Linq for .Net 6");
            var demoCollection = Enumerable.Range(1, 25).Select(x=> new User(x,$"User{x}"));
            
            Console.WriteLine("Complete Elements {0}", demoCollection.ToPrintString());
            Console.WriteLine();
            Console.WriteLine("Support for Range & Index");
            Console.WriteLine("Enumerable.Take 10th to 10th from end: {0}", demoCollection.Take(10..^10).ToPrintString());
            Console.WriteLine();
            Console.WriteLine("Support for Default");
            Console.WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}:", demoCollection.FirstOrDefault(x => x.id > 50, new User(-1,"DefaultUser")));
            Console.WriteLine("Enumerable.LastOrDefault(defaultValue) : {0}", demoCollection.LastOrDefault(x => x.id > 50, new User(-1, "DefaultUser")));
            Console.WriteLine("Enumerable.SingleOrDefault(defaultValue) : {0}", demoCollection.SingleOrDefault(x => x.id > 50, new User(-1, "DefaultUser")));

            Console.ReadLine();
       }

        
        
    }
    public record User(int id, string Name);
    public static class EnumerableExtensions
    {
        public static string ToPrintString(this IEnumerable<User> source) => string.Join(",", source);
    }

}
