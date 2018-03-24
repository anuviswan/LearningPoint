using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public class Person : IPerson
    {
        public long ID { get; set; }

        public IList<IEmployementDetail> GetEmployementHistory()
        {
            // Get From Db
            return new List<IEmployementDetail>();
            
        }
    }
}
