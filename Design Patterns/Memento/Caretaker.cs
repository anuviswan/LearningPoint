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

        public Memento GoBack(int level)
        {
            return _stateMemory.Reverse().Skip(level-1).First();
        }

        public Memento First()
        {
            return _stateMemory.First();
        }

        public Memento Last()
        {
            return _stateMemory.Last();
        }
    }
}
