using System.Collections.Generic;

namespace Strategy
{
    public interface ISortAlgorithm<T>
    {
        IEnumerable<T> Sort(IEnumerable<T> dataCollection);
    }
}
