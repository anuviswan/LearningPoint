using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class MockDataService : IDataService
    {
        public string GetName() => "Jia Anu";

        public Parent GetParents()
        {
            return new Parent
            {
                Father = "Anu Viswan",
                Mother = "Sreena Anu"
            };
        }
    }
}
