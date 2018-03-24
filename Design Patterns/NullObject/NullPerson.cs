using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public class NullPerson : IPerson
    {
        public long ID { get; set; } 

        public IList<IEmployementDetail> GetEmployementHistory()
        {
            // Just return a default object
            return new List<IEmployementDetail>();

        }
    }
}
