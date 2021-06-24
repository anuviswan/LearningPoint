using System;
using System.Collections.Generic;

namespace Strategy.SortAlgorithms
{
    public class BubbleSort<T> : ISortAlgorithm<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> dataCollection)
        {
            Console.WriteLine($"Sorting {nameof(BubbleSort<T>)}");
            return default;
        }
    }
}
