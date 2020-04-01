using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automapper.UseIoc.Models
{
    public interface IHuman
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
    }
}
