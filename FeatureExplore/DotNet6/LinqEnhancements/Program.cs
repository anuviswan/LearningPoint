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
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}:", demoCollection.FirstOrDefault(x => x.Id > 50, new User(-1,"DefaultUser")));
            WriteLine("Enumerable.LastOrDefault(defaultValue) : {0}", demoCollection.LastOrDefault(x => x.Id > 50, new User(-1, "DefaultUser")));
            WriteLine("Enumerable.SingleOrDefault(defaultValue) : {0}", demoCollection.SingleOrDefault(x => x.Id > 50, new User(-1, "DefaultUser")));
            WriteLine();

            WriteLine("Support for Zip with 3 IEnumerables");
            foreach(var (first,second,third) in demoCollection.Take(..5).Zip(demoCollection.Take(5..10), demoCollection.Take(10..15)))
            {
                WriteLine($"First: {first.Id}, Second: {second.Id}, Third: {third.Id}");
            }

            WriteLine();
            WriteLine("Support for Chunk");
            foreach(var chunk in demoCollection.Chunk(5))
            {
                WriteLine("Chunk : {0}", chunk.Select(x=>x.Id).ToPrintString());
            }
            WriteLine();

            var secondCollection = GetData(10);
            WriteLine("Support for Key Selector in ExceptBy/IntersectBy/DistinctBy/UnionBy/MaxBy/MinBy");
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.ExceptBy(secondCollection.Select(x=>x.Name),user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.IntersectBy(secondCollection.Select(x => x.Name), user => user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.DistinctBy(user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.UnionBy(secondCollection,user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.MaxBy(user=>user.Id));
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.MinBy(user=>user.Id));
            ReadLine();
       }

        private static IEnumerable<User> GetData(int maxCount)
        {
            var random = new Random();
            for (int i = 0; i < maxCount; i++)
                yield return new User(i, $"User{random.Next(1,5)}");
        }
    }
    public record User(int Id, string Name);
    public static class EnumerableExtensions
    {
        public static string ToPrintString<T>(this IEnumerable<T> source) => string.Join(",", source);
    }

}
