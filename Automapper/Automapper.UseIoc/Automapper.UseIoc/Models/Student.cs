using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper.UseIoc.Models
{
    public class Student : IHuman
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
        public Address Address { get; set; }
    }
}
