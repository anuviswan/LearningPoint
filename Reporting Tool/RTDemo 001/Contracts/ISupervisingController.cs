using RTDemo_001.Models;
using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface ISupervisingController
    {
        void AttachReport(IList<ProductModel> productCollection,string fileName);
    }
}
