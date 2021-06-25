using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LinqEnhancements
{
    public static class OrDefaultDemo
    {
        public static void NewApproach()
        {
            WriteLine("Using .Net 6");
            var data = Data.Generate(10);

            // .Net 6
            var firstOrDefault = data.FirstOrDefault(x => x.Id > 100, new User(-1, "GhostUser"));
            var lastOrDefault = data.LastOrDefault(x => x.Id > 100, new User(-1, "GhostUser"));
            var singleOrDefault = data.SingleOrDefault(x => x.Id > 100, new User(-1, "GhostUser"));
            WriteLine($"FirstOrDefault:{firstOrDefault}");
            WriteLine($"LastOrDefault:{lastOrDefault}");
            WriteLine($"SingleOrDefault:{singleOrDefault}");
        }

        public static void OldApproach()
        {
            WriteLine("Using Old approach");
            var data = Data.Generate(10);

            // Prior to .Net 6
            var firstOrDefault = data.Where(x => x.Id > 100).DefaultIfEmpty(new User(-1, "GhostUser")).First();
            var lastOrDefault = data.Where(x => x.Id > 100).DefaultIfEmpty(new User(-1, "GhostUser")).Last();
            var singleOrDefault = data.Where(x => x.Id > 100).DefaultIfEmpty(new User(-1, "GhostUser")).Single();
            WriteLine($"FirstOrDefault:{firstOrDefault}");
            WriteLine($"LastOrDefault:{lastOrDefault}");
            WriteLine($"SingleOrDefault:{singleOrDefault}");
        }
    }
}
