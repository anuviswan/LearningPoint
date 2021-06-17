using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Products;

namespace FactoryMethod.Factories
{
    public class ProductGammaFactory : ProductFactoryBase
    {
        protected override IProduct GetProduct()
        {
            return new ProductGamma();
        }
    }
}
