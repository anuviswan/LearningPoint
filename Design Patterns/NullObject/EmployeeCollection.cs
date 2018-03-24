using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public static class EmployeeCollection
    {
        private static Dictionary<long, IPerson> _personDictionary = new Dictionary<long, IPerson>()
        {
            [1] = new Person() { ID = 1 },
            [2] = new Person() { ID = 2 }
        };
        public static IPerson GetEmployee(long ID)
        {
            if (_personDictionary.ContainsKey(ID))
                return _personDictionary[ID];
            else
            {
                //return null; // Not Ideal
                return new NullPerson();
            }
        }
    }
}
