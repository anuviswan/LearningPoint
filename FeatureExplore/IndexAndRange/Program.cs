using System;
using System.Linq;

namespace CSharp8.IndexAndRange
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputCollection = Enumerable.Range(1, 10).ToArray();

            Log($"Original Collection : {string.Join(',', inputCollection)}");
            Break();

            Log("Index Operator");
            Break();
            // Get the 2nd element from end in the array
            Log($"Second Last Element From Collection - With Uniary Prefix Hat Operator");
            Log($"inputCollection[^2]={inputCollection[^2]}");
            Break();

            Log($"Second Element From Collection - Normal Syntax");
            Log($"inputCollection[2]={inputCollection[2]}");
            Break();


            Log("Range Operator");
            Break();

            Log($"2nd to Fifth element from Collection");
            Log($"inputCollection[1..5]={string.Join(',',inputCollection[1..5])}");
            Break();


            Log($"All elements starting from the 5th element in collection");
            Log($"inputCollection[5..]={string.Join(',', inputCollection[5..])}");
            Break();

            Log($"First 5 elements in collection");
            Log($"inputCollection[..5]={string.Join(',', inputCollection[..5])}");
            Break();

            Log($"Elements starting from first till the 3th element from last");
            Log($"inputCollection[..^3]={string.Join(',', inputCollection[..^3])}");
            Break();

            Log($"Last 3 elements in collection");
            Log($"inputCollection[^3..]={string.Join(',', inputCollection[^3..])}");
            Break();

            Log($"Complete List");
            Log($"inputCollection[..]={string.Join(',', inputCollection[..])}");
            Break();

            Console.ReadLine();
        }

        static void Break()
        {
            Console.WriteLine();
        }

        static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
