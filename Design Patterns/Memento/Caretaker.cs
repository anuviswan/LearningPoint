using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDP
{
    public class Caretaker<TSource>
    {

        private IList<Memento> _stateMemory;

        public Caretaker()
        {
            _stateMemory = new List<Memento>();
        }

        public void Add(Memento instance)
        {
            _stateMemory.Add(instance);
        }

        public IQueryable<Memento> Instances()
        {
            return _stateMemory.AsQueryable();
        }
    }
}
