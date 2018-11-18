using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sprache001
{
    public class TableParser
    {
        public static readonly Parser<string> Alphanumeric = from leadingspaces in Parse.WhiteSpace.Many()
                                                       from first in Parse.Letter.Once()
                                                       from rest in Parse.LetterOrDigit.Many()
                                                       select new string(first.Concat(rest).ToArray());

        public static readonly Parser<string> Header = Alphanumeric;

        public static readonly Parser<List<string>> HeaderCollection = from header in Header.AtLeastOnce().Token() select header.ToList();

        public static readonly Parser<double> DecimalValue = from value in Parse.Decimal.Token()
                                                      select double.Parse(value);

        public static readonly Parser<IEnumerable<double>> ValueCollection = from value in DecimalValue.Many().Except(Parse.LineEnd).Token()
                                                                            select value.ToList();


        public static readonly Parser<DateTime> DateTime = from day in Parse.Number.Token()
                                                           from separator1 in Parse.Char('/')
                                                           from month in Parse.Number
                                                           from separator2 in Parse.Char('/')
                                                           from year in Parse.Number
                                                           from whitespace in Parse.WhiteSpace.Many()
                                                           from hour in Parse.Number
                                                           from separator3 in Parse.Char(':')
                                                           from minute in Parse.Number
                                                           from separator4 in Parse.Char(':')
                                                           from seconds in Parse.Number.Token()
                                                           select new DateTime(int.Parse(year), int.Parse(month), int.Parse(day),int.Parse(hour),int.Parse(minute),int.Parse(seconds));

        public static readonly Parser<Table> Table = from headers in HeaderCollection
                                                     from valuelist in ValueCollection
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
