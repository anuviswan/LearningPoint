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

            OrDefaultDemo.OldApproach();
            OrDefaultDemo.NewApproach();

            ZipDemo.OldApproach();
            ZipDemo.NewApproach();

            var demoCollection = Data.Generate(25); 

            WriteLine("Complete Elements {0}", demoCollection.ToPrintString());

            WriteLine("Support for TryGetNonEnumeratedCount");
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}", $"IsNonEnumeratedCount:{demoCollection.TryGetNonEnumeratedCount(out var enumCount)},Count:{enumCount}");
            WriteLine("Enumerable.FirstOrDefault(defaultValue) {0}", $"IsNonEnumeratedCount:{demoCollection.ToList().TryGetNonEnumeratedCount(out var listCount)},Count:{listCount}");
            WriteLine();

            WriteLine("Support for Range & Index");
            WriteLine("Enumerable.Take 10th to 10th from end: {0}", demoCollection.Take(10..^10).ToPrintString());
            WriteLine();

            WriteLine("Support for Chunk");
            foreach(var chunk in demoCollection.Chunk(5))
            {
                WriteLine("Chunk : {0}", chunk.Select(x=>x.Id).ToPrintString());
            }
            WriteLine();

            var secondCollection = Data.Generate(10);
            WriteLine("Support for Key Selector in ExceptBy/IntersectBy/DistinctBy/UnionBy/MaxBy/MinBy");
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.ExceptBy(secondCollection.Select(x=>x.Name),user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.IntersectBy(secondCollection.Select(x => x.Name), user => user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.DistinctBy(user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.UnionBy(secondCollection,user=>user.Name).ToPrintString());
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.MaxBy(user=>user.Id));
            WriteLine("Enumerable.ExceptBy(User.UserName) {0}", demoCollection.MinBy(user=>user.Id));
            ReadLine();
       }

        

    }
    

}
