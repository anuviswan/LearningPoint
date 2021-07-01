using System.Collections.Generic;

namespace Strategy
{
    public interface IProduct<T>
    {
        ISortAlgorithm<T> SortingAlgorithm { get; set; }
        IRead<T> Reader { get; set; }
        void Display(IEnumerable<T> data);
        IEnumerable<T> Read(string fileName);
        IEnumerable<T> Sort(IEnumerable<T> data);
    }
}
