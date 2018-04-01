using Decorator.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Demo code for Decorator Design Pattern
namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza vegPizza = new MargheritaPizza();
            var vegPizzacheezeCrust = new CheeseCrust(vegPizza); // Added Decorator

            IPizza nonVegPizza = new ChickenTikkaPizza();
            var chickenPizzacheezeCrust = new CheeseCrust(nonVegPizza); // Added Decorator
            var chickenPizzacheezeCrustAndExtraGoldenCoren = new ExtraGoldenCorn(chickenPizzacheezeCrust); // Added Decorator

            Console.WriteLine($"{vegPizzacheezeCrust.Description}, Price  : {vegPizzacheezeCrust.CalculatePrice()}");
            Console.WriteLine($"{chickenPizzacheezeCrustAndExtraGoldenCoren.Description}, Price  : {chickenPizzacheezeCrustAndExtraGoldenCoren.CalculatePrice()}");
            Console.ReadLine();


        }
    }
}
