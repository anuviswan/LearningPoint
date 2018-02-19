using RTDemo_001.Models;
using System.Collections.Generic;

namespace RTDemo_001.Contracts
{
    public interface IPreviewDataViewModel
    {
        void Show(IList<ProductModel> productCollection);
    }
}
