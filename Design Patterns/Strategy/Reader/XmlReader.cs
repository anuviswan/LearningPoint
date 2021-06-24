using System;
using System.Collections.Generic;

namespace Strategy.Read
{
    public class XmlReader<T> : IRead<T>
    {
        public IEnumerable<T> ReadData(string fileName)
        {
            Console.WriteLine($"Reading using {nameof(XmlReader<T>)}");
            return default;
        }
    }
}
