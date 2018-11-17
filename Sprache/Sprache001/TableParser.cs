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
        public static readonly Parser<List<string>> Headers = null;// Parse.Letter.AtLeastOnce().Text().Token();
    }

    public class Table
    {
        public List<string> Headers { get; set; }
    }
}
