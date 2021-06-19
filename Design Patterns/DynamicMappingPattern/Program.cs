using System;
using System.Collections.Generic;
using DynamicMappingPattern.Products;
using DynamicMappingPattern.ResolverFactories;

namespace DynamicMappingPattern
{
    class Program
    {
        /// <summary>
        ///  This is a INCOMPLETE CODE. This is NOT a pattern, but an attempt to create a better way for dynamic mapping
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Executing Client Code");

            Console.WriteLine("This code is still incomplete. It is an attempted pattern for dynamic mapping. ");

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
