using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkForEach
{
    public class LoopTest
    {
        [Benchmark]
        [ArgumentsSource(nameof(IEnumerableCollection))]
        public void ForEachIEnumerable(IEnumerable<int> collection)
        {
            foreach (var item in collection)
            {
                DoSomething(item);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(IListCollection))]
        public void ForEachIList(IList<int> collection)
        {
            foreach (var item in collection)
            {
                DoSomething(item);
            }
        }

        [Benchmark]
        [ArgumentsSource(nameof(ListCollection))]
        public void ForEachList(List<int> collection)
        {
            foreach (var item in collection)
            {
                DoSomething(item);
            }
        }

        public void DoSomething(int num)
        {

        }


        public IEnumerable<IEnumerable<int>> IEnumerableCollection()
        {
            yield return Enumerable.Range(1, 99999); 
        }
        public IEnumerable<IList<int>> IListCollection ()
        {
            yield return Enumerable.Range(1, 99999).ToList();
        }
        public IEnumerable<List<int>> ListCollection()
        {
            yield return Enumerable.Range(1, 99999).ToList();
        }
    }
}
