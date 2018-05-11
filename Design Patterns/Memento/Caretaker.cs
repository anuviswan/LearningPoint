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

        public void Add(Memento instance) => _stateMemory.Add(instance);

        public Memento GoBack(int level) =>  _stateMemory.Reverse().Skip(level-1).First();

        public Memento First() => _stateMemory.First();
        public Memento First(Predicate<Memento> predicate) => _stateMemory.First(x=>predicate(x));

        public Memento Last() => _stateMemory.Last();
        public Memento Last(Predicate<Memento> predicate) => _stateMemory.Last(x => predicate(x));
    }
}
