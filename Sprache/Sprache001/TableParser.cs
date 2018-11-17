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
        public static readonly Parser<string> AlphanumbericString = from leadingspaces in Parse.WhiteSpace.Many()
                                                       from first in Parse.Letter.Once()
                                                       from rest in Parse.LetterOrDigit.Many()
                                                       select new string(first.Concat(rest).ToArray());
        public static readonly Parser<List<string>> Headers = from header in AlphanumbericString.AtLeastOnce().Token() select header.ToList();
    }

    public class Table
    {
        public List<string> Headers { get; set; }

    }
}
