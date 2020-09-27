using BenchmarkDotNet.Running;
using System;

namespace BenchmarkMemoryCache
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MemoryCacheRunner>();
        }
    }
}
