using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Products;

namespace FactoryMethod.Factories
{
    public class ProductBetaFactory:ProductFactoryBase
    {
        protected override IProduct GetProduct()
        {
            return new ProductBeta();
        }
    }
}
