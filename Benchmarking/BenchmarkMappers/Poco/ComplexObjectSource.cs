using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkMappers.Poco
{
    public class ComplexObjectSource
    {
        public int Id { get; set; }

        public IEnumerable<int> Values { get; set; }

        public List<ComplexObjectSource> ComplexCollection { get; set; }
    }
}
