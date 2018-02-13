using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface INewAgeHRSoftware
    {
        List<string> EmployeeList { get;  }
    }
    public class NewAgeHRSoftware : INewAgeHRSoftware
    {
        public List<string> EmployeeList
        {
            get
            {
                return new List<string>();
            }

         
        }
    }

    
}
