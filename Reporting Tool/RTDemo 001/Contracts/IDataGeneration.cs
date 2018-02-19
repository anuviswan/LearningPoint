using RTDemo_001.Models;
using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface IDataGeneration
    {
        IList<ProductModel> Load(string fileName=null);
    }
}
