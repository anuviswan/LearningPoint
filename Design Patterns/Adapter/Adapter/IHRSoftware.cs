using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IHRSoftware
    {
        List<string> GetEmployeeNameList();
    }

    public class HRSoftware : IHRSoftware
    {
        public List<string> GetEmployeeNameList()
        {
            return new List<string>() { "Jia", "Anu", "Sreena" };
        }
    }
}
