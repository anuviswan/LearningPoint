using System;

namespace FactoryMethod.Products
{
    public class ProductAlpha : IProduct
    {
        public void DoOperation()
        {
            Console.WriteLine($"{nameof(ProductAlpha)}.{nameof(IProduct.DoOperation)}");
        }

        public void Initialilze()
        {
            Console.WriteLine($"{nameof(ProductAlpha)}.{nameof(IProduct.Initialilze)}");
        }

        public void Shutdown()
        {
            Console.WriteLine($"{nameof(ProductAlpha)}.{nameof(IProduct.Shutdown)}");
        }
    }
}
