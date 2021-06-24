using System;
using System.Collections.Generic;

namespace Strategy.Read
{
    public class JsonReader<T> : IRead<T>
    {
        public IEnumerable<T> ReadData(string fileName)
        {
            Console.WriteLine($"Reading using {nameof(JsonReader<T>)}");
            return default;
        }
    }
}
