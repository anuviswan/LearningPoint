using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.Products;

namespace FactoryMethod.Factories
{
    public abstract class ProductFactoryBase
    {
        protected abstract IProduct GetProduct();

        public void Run()
        {
            var product = GetProduct();
            product.Initialilze();
            product.DoOperation();
            product.Shutdown();
        }
    }
}
