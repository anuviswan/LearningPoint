using BenchmarkDotNet.Running;
using System;

namespace BenchmarkingAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Tests>();
        }
    }
}
