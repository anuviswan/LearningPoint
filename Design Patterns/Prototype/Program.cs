using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personA = new Person { FirstName = "John", LastName= "Burton", Age = 35 };
            Person personB = personA.Clone() as Person;

            Console.WriteLine($"Person A : {personA.LastName},{personA.FirstName} - Age : {personA.Age}");
            Console.WriteLine($"Person B : {personB.LastName},{personB.FirstName} - Age : {personB.Age}");
            Console.ReadLine();
        }
    }
}
