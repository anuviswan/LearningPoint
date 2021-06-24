using System;
using System.Collections.Generic;

namespace Strategy.Read
{
    public class CsvReader<T> : IRead<T>
    {
        public IEnumerable<T> ReadData(string fileName)
        {
            Console.WriteLine($"Reading using {nameof(CsvReader<T>)}");
            return default;
        }
    }
}
