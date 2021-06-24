using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LinqEnhancements
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("This is demo code for enhancements in Linq for .Net 6");
            var demoCollection = GetData(25); 

            WriteLine("Complete Elements {0}", demoCollection.ToPrintString());

            WriteLine("Support for TryGetNonEnumeratedCount");
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}", $"IsNonEnumeratedCount:{demoCollection.TryGetNonEnumeratedCount(out var enumCount)},Count:{enumCount}");
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}", $"IsNonEnumeratedCount:{demoCollection.ToList().TryGetNonEnumeratedCount(out var listCount)},Count:{listCount}");
            WriteLine();

            WriteLine("Support for Range & Index");
            WriteLine("Enumerable.Take 10th to 10th from end: {0}", demoCollection.Take(10..^10).ToPrintString());
            WriteLine();

            WriteLine("Support for Default in FirstOrDefault/LastOrDefault/SingleOrDefault");
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}:", demoCollection.FirstOrDefault(x => x.id > 50, new User(-1,"DefaultUser")));
            WriteLine("Enumerable.LastOrDefault(defaultValue) : {0}", demoCollection.LastOrDefault(x => x.id > 50, new User(-1, "DefaultUser")));
            WriteLine("Enumerable.SingleOrDefault(defaultValue) : {0}", demoCollection.SingleOrDefault(x => x.id > 50, new User(-1, "DefaultUser")));

            WriteLine("Support for Key Selector in DistinctBy");
            WriteLine("Enumerable.DistinctBy(User.UserName) {0}", demoCollection.DistinctBy(x => x.Name).ToPrintString());

            var secondCollection = GetData(10);
            //WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.ExceptBy(secondCollection,user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.UnionBy(secondCollection,user=>user.Name).ToPrintString());


            ReadLine();
       }

        private static IEnumerable<User> GetData(int maxCount)
        {
            var random = new Random();
            for (int i = 0; i < maxCount; i++)
                yield return new User(i, $"User{random.Next(1,5)}");
        }


        
        
    }
    public record User(int id, string Name);
    public static class EnumerableExtensions
    {
        public static string ToPrintString(this IEnumerable<User> source) => string.Join(",", source);
    }

}
