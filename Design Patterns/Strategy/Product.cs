using System;
using System.Collections.Generic;

namespace Strategy
{
    public class Product<T> : IProduct<T>
    {
        public ISortAlgorithm<T> SortingAlgorithm { get; set; }
        public IRead<T> Reader { get; set; }

        public IEnumerable<T> Sort(IEnumerable<T> data)
        {
            return SortingAlgorithm.Sort(data);
        }
        public IEnumerable<T> Read(string fileName)
        {
            return Reader.ReadData(fileName);
        }

        public void Display(IEnumerable<T> data)
        {
            Console.WriteLine("Displaying Data");
        }
    }
}
