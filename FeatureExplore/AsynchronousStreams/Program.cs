using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsynchronousStreams
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach (var item in Generate(10))
            {
                Console.WriteLine(item);
            };
            Console.ReadLine();
        }

        public static async IAsyncEnumerable<int> Generate(int max)
        {
            for (int i = 0; i < max; i++)
            {
                await Task.Delay(1000);
                yield return i;
            }
        }
    }
}
