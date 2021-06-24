using System;
using System.Collections.Generic;

namespace Strategy.SortAlgorithms
{
    class BucketSort<T> : ISortAlgorithm<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> dataCollection)
        {
            Console.WriteLine($"Sorting {nameof(BucketSort<T>)}");
            return default;
        }
    }
}
