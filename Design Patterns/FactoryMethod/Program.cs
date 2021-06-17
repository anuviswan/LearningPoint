using System;
using FactoryMethod.Factories;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientCode(new ProductAlphaFactory());
            ClientCode(new ProductBetaFactory());
            ClientCode(new ProductGammaFactory());
        }

        static void ClientCode(ProductFactoryBase factory)
        {
            Console.WriteLine("Executing Client Code");
            factory.Run();
            Console.WriteLine();
        }
    }
}
