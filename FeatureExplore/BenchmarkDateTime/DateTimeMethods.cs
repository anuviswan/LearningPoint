using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDateTime
{
    public class DateTimeMethods
    {
        private DateTime testData = DateTime.Now;

        [Benchmark]
        public DateTime FloorWithNewOperator() => new DateTime(testData.Year, testData.Month, testData.Day, testData.Hour, 0, 0);

        [Benchmark]
        public DateTime FloorWithAddOperator() => testData.AddMinutes(-testData.Minute).AddSeconds(-testData.Second);

        [Benchmark]
        public DateTime FloorWithTicks()
        {
            var originalTicks = testData.Ticks;
            var hoursSinceEpoch = originalTicks / TimeSpan.TicksPerHour;
            var newTicks = hoursSinceEpoch * TimeSpan.TicksPerHour;
            return new DateTime(newTicks);

        }
    }
}
