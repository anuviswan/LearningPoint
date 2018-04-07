using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new SmartPhone(new KitKat());
            var newAgePhone = new NewAgeSmartPhone(new KitKat());

            phone.Phone("Wife");
            newAgePhone.Phone("Wife");
            Console.ReadLine();
        }
    }
}
