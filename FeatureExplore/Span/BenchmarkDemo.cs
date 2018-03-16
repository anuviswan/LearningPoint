using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Span
{
    [MemoryDiagnoser]
    public class BenchmarkDemo
    {
        [Params(10, 100, 400)]
        public int IterationLimit { get; set; }


        [Benchmark]
        public void UsingSubString()
        {
            string keyString = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            for (int i = 0; i < IterationLimit; i++)
                DummyStringMethod(keyString.Substring(0, i));
        }

        [Benchmark]
        public void UsingSpan()
        {
            ReadOnlySpan<char> keyString = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.".AsReadOnlySpan();
            for (int i = 0; i < IterationLimit; i++)
                DummySpanMethod(keyString.Slice(0, i));
        }

        void DummyStringMethod(string _) { }

        void DummySpanMethod(ReadOnlySpan<char> _) { }
    }
}
