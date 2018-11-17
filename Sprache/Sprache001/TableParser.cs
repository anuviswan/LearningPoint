using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprache001
{
    public class TableParser
    {
        public static readonly Parser<string> Header = from header in Parse.Letter.AtLeastOnce().Text().Token()
                                                       select header;
        public static readonly Parser<List<string>> Headers = from header in Header.AtLeastOnce() select header.ToList();
    }

    public class Table
    {
        public List<string> Headers { get; set; }

    }
}
