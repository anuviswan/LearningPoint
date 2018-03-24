using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public interface IEmployementDetail
    {
        string CompanyName { get; set; }
        string Location { get; set; }
        DateTime DoJ { get; set; }
        DateTime DoE { get; set; }
    }
}
