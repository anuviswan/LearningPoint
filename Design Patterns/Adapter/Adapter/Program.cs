using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching from HRSoftware");
            IHRSoftware hrsoft = new HRSoftware();
            foreach (var item in hrsoft.GetEmployeeNameList())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Fetching from NewAgeHRSoftware - Adapter via Inheritence");
            INewAgeHRSoftware newhrsoftInheritence = new AdapterWithInheritence();
            foreach (var item in newhrsoftInheritence.EmployeeList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Fetching from NewAgeHRSoftware - Adapter via DI");
            INewAgeHRSoftware newhrsoftDI = new AdapterWithDI(new HRSoftware());
            foreach (var item in newhrsoftInheritence.EmployeeList)
            {
                Console.WriteLine(item);
            }
            
            
            Console.WriteLine("Fetching from NewAgeHRSoftware - Adapter via Generics");
            INewAgeHRSoftware newhrsoftGenerics= new AdapterWithGenerics<HRSoftware>(new HRSoftware());
            foreach (var item in newhrsoftGenerics.EmployeeList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
