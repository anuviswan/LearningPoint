using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp11
{
    public class NullChecks
    {
        private class CustomConfiguration : ManualConfig
        {
            public CustomConfiguration()
            {
                AddJob(Job.Default.WithRuntime(CoreRuntime.Core50));
                AddJob(Job.Default.WithRuntime(CoreRuntime.Core60));
            }
        }
        [Benchmark]
        public void NullCheckUsingCSharp10(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
        }

    }
}
