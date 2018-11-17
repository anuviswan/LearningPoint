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

        public static readonly Parser<double> DecimalValueParser = from leadingSpace in Parse.WhiteSpace.Many()
                                                      from value in Parse.Digit.Many().Text()
                                                      from point in Parse.Char('.').Optional()
                                                      from decimalValue in Parse.Digit.Many().Text().Optional()
                                                      select Double.Parse($"{value}.{decimalValue.GetOrDefault()}");
    }

    public class Table
    {
        public List<string> Headers { get; set; }

    }
}
