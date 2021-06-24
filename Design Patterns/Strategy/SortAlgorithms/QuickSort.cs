using System;
using System.Collections.Generic;

namespace Strategy.SortAlgorithms
{
    public class QuickSort<T> : ISortAlgorithm<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> dataCollection)
        {
            Console.WriteLine($"Sorting {nameof(QuickSort<T>)}");
            return default;
        }
    }
}
