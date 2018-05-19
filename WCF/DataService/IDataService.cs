using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public interface IDataService
    {
        string GetName();
        Parent GetParents(); 
    }

    public class Parent
    {
        public string Father { get; set; }
        public string Mother { get; set; }
    }
}
