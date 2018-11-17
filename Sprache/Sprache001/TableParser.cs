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
        public static readonly Parser<string> AlphaNumericParser = from leadingspaces in Parse.WhiteSpace.Many()
                                                       from first in Parse.Letter.Once()
                                                       from rest in Parse.LetterOrDigit.Many()
                                                       select new string(first.Concat(rest).ToArray());

        public static readonly Parser<List<string>> HeaderListParser = from header in AlphaNumericParser.AtLeastOnce().Token() select header.ToList();

        public static readonly Parser<double> DecimalValueParser = from value in Parse.Decimal.Token()
                                                      select Double.Parse(value);

        public static readonly Parser<List<double>> ValueList = from value in DecimalValueParser.Many().Token()
                                                                select value.ToList();
    }

    public class Table
    {
        public List<string> Headers { get; set; }

    }
}
