using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{

    public class AdapterWithInheritence : HRSoftware, INewAgeHRSoftware
    {
        
        public List<string> EmployeeList
        {
            get
            {
                return this.GetEmployeeNameList();
            }
        }
    }

    public class AdapterWithDI : INewAgeHRSoftware
    {
        private IHRSoftware _HRInstance;
        public AdapterWithDI(IHRSoftware HRSoftInstance)
        {
            _HRInstance = HRSoftInstance;
        }
        public List<string> EmployeeList
        {
            get
            {
                return _HRInstance.GetEmployeeNameList();
            }

        }
    }


    public class AdapterWithGenerics<T> : INewAgeHRSoftware where T : HRSoftware
    {
        private T _HRInstance;

        public AdapterWithGenerics(T Instance)
        {
            _HRInstance = Instance;
        }
       
        public List<string> EmployeeList
        {
            get
            {
                return _HRInstance.GetEmployeeNameList();
            }

        }
    }
}
