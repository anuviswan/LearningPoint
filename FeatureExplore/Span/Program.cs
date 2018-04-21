using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span
{
    public class Program
    {
        static void Main()
        {
            // Execute the Benchmark 
            ExecuteTypeCast();
            ExecuteBenchmark();

        }

        [Conditional("RELEASE")]
        static void ExecuteBenchmark() => BenchmarkRunner.Run<BenchmarkDemo>();

        [Conditional("DEBUG")]
        static void ExecuteTypeCast() => new TypeCast().TypeCastPrimitiveTypes();

    }
}
