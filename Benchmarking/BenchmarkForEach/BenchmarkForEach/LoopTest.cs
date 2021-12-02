using BenchmarkDotNet.Attributes;
using System.Linq.Expressions;

namespace BenchmarkForEach
{
    public class LoopTest
    {
        private const int MaxCount = 1_000_000;

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


        public IEnumerable<IEnumerable<int>> IEnumerableCollection()
        {
            yield return Enumerable.Range(1, MaxCount); 
        }
        public IEnumerable<IList<int>> IListCollection ()
        {
            yield return Enumerable.Range(1, MaxCount).ToList();
        }
        public IEnumerable<List<int>> ListCollection()
        {
            yield return Enumerable.Range(1, MaxCount).ToList();
        }

        public void DoSomething(int num) => Expression.Empty();
        
    }
}
