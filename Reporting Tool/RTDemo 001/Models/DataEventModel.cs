using System.Collections.Generic;

namespace RTDemo_001.Models
{
    public class DataEventModel
    {
        public DataEventModel(IList<ProductModel> productCollection) => ProductCollection = productCollection;
        public IList<ProductModel> ProductCollection { get; set; }
    }
}
