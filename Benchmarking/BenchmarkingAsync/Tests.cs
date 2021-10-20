using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkingAsync
{
    public class Tests
    {
        public IEnumerable<string> PersonReferences = new List<string>();
        public ObservableCollection<Person> ProcessedCollection = new ObservableCollection<Person>();

        public Tests()
        {
            PersonReferences = Enumerable.Range(1, 50).Select(x => $"Person {x}").ToList();
        }

        [Benchmark]
        public async Task TestWhenAll()
        {
            var taskList = new List<Task<Person>>();
            //foreach(var item in PersonReferences)
            //{
            //    taskList.Add(Task.Run(() => MockApi(item)));
            //}

            taskList = PersonReferences.Select(x => Task.Run(()=>MockApi(x))).ToList();

            var persons = await Task.WhenAll(taskList);

            foreach (var person in persons)
            {
                ProcessedCollection.Add(person);
            }
        }

        [Benchmark]
        public async Task TestAwait()
        {
            var taskList = new List<Task<Person>>();
            foreach (var item in PersonReferences)
            {
                var person = await MockApi(item);
                ProcessedCollection.Add(person);
            }
        }

        [Benchmark]
        public async Task TestForEachAwait()
        {
            var taskList = new List<Task<Person>>();
            Parallel.ForEach(PersonReferences, async (item) =>
            {
                taskList.Add(Task.Run(() => MockApi(item)));
            });
            var persons = await Task.WhenAll(taskList);

            foreach (var person in persons)
            {
                ProcessedCollection.Add(person);
            }
        }


        [Benchmark]
        public async Task TestAsyncPForEachAwait()
        {
            var taskList = new List<Task<Person>>();
            var cancellationSrc = new CancellationTokenSource();
            var token = cancellationSrc.Token;
            await Parallel.ForEachAsync(PersonReferences, async (item, token) => 
            {
                var person = await MockApi(item);
                ProcessedCollection.Add(person);
            });
        }

        public async Task<Person> MockApi(string person)
        {
            await Task.Delay(300);
            return new Person
            {
                Name = person
            };
        }
    }


    public class Person
    {
        public string Name { get; set; }
    }
}
