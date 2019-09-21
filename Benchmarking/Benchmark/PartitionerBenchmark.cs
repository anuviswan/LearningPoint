using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class PartitionerBenchmark
    {
        [Benchmark]
        public void ParallelLoopWithoutPartioner()
        {
            var maxValue = 100000;
            var sum = 0L;

            Parallel.For(0, maxValue, (value) =>
            {
                Interlocked.Add(ref sum, value);
            });
        }

        [Benchmark]
        public void ParallelLoopWithPartioner()
        {
            var maxValue = 100000;
            var sum = 0L;
            var partioner = Partitioner.Create(0,maxValue);

            Parallel.ForEach(partioner, range =>
            {
                var (minValueInRange, maxValueInRange) = range;
                var subTotal = 0;
                for (int value = minValueInRange; value < maxValueInRange; value++)
                {
                    subTotal += value;
                }
                Interlocked.Add(ref sum, subTotal);
            });
        }
    }
}
