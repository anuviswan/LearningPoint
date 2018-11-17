using Sprache;
using System.Collections.Generic;
using System.Linq;

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
                                                      select double.Parse(value);

        public static readonly Parser<IEnumerable<double>> LineOfValueList = from value in DecimalValueParser.Many().Except(Parse.LineEnd).Token()
                                                                            select value.ToList();



        public static readonly Parser<Table> Table = from headers in HeaderListParser
                                                     from valuelist in LineOfValueList
                                                     select new Table(headers, valuelist.ToList());

    }

    public class Table
    {
        public Table(List<string> headers,List<double> Values)
        {
            Headers = headers;
            var groupedList = Values.ChunkBy(headers.Count);
            foreach (var item in groupedList)
            {
                ValueList.Add(headers.Zip(item, (x, y) => new { Key = x, Value = y }).ToDictionary(x => x.Key, y => y.Value));
            }
        }
        public List<string> Headers { get; set; } = new List<string>();
        public List<Dictionary<string, double>> ValueList { get; set; } = new List<Dictionary<string, double>>();
    }

    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
