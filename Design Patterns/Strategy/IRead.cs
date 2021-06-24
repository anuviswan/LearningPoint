using System.Collections.Generic;

namespace Strategy
{
    public interface IRead<T>
    {
        IEnumerable<T> ReadData(string fileName);
    }
}
