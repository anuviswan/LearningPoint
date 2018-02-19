using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface IReport
    {
        void RegisterData<T>(IList<T> productCollection);
    }
}
