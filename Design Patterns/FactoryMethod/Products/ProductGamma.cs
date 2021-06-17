using System;

namespace FactoryMethod.Products
{
    public class ProductGamma : IProduct
    {
        public void DoOperation()
        {
            Console.WriteLine($"{nameof(ProductGamma)}.{nameof(IProduct.DoOperation)}");
        }
        public void Initialilze()
        {
            Console.WriteLine($"{nameof(ProductGamma)}.{nameof(IProduct.Initialilze)}");
        }

        public void Shutdown()
        {
            Console.WriteLine($"{nameof(ProductGamma)}.{nameof(IProduct.Shutdown)}");
        }
    }
}
