using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span
{
    public class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<BenchmarkDemo>();
        }
    }
}
