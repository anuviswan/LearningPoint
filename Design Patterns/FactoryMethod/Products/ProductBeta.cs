using System;

namespace FactoryMethod.Products
{
    public class ProductBeta : IProduct
    {
        public void DoOperation()
        {
            Console.WriteLine($"{nameof(ProductBeta)}.{nameof(IProduct.DoOperation)}");
        }

        public void Initialilze()
        {
            Console.WriteLine($"{nameof(ProductBeta)}.{nameof(IProduct.Initialilze)}");
        }

        public void Shutdown()
        {
            Console.WriteLine($"{nameof(ProductBeta)}.{nameof(IProduct.Shutdown)}");
        }
    }
}
