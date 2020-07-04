using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public void Deconstruct(out string firstName, out string lastName, out int age) => (firstName, lastName, age) = (FirstName, LastName, Age);
    }
}
