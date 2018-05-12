using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMemento
{
    public class Caretaker<TSource>
    {
        private IList<Memento<TSource>> _stateMemory;

        public Caretaker()
        {
            _stateMemory = new List<Memento<TSource>>();
        }

        public void Add(Memento<TSource> instance) => _stateMemory.Add(instance);
        public Memento<TSource> GetLastKnownState(int index = 1) => _stateMemory.Reverse().Skip(index -1).First();

    }
}
