using System;
using System.Collections.Generic;
using DynamicMappingPattern.Products;
using DynamicMappingPattern.ResolverFactories;

namespace DynamicMappingPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executing Client Code");

            var productCollection = new List<IProduct>()
            {
                new ProductA(),
                new ProductB(),
                new ProductC()
            };

            foreach(var product in productCollection)
            {
                ClientCode(product);
            }
            Console.ReadLine();
        }

        static void ClientCode(IProduct product)
        {
            Console.WriteLine($"Resolving statergy for type {product.GetType()}");
            var resolver = new DynamicMappingResolverAlpha();
            
            resolver.DoOperation(product);
            Console.WriteLine();
        }
    }
}
