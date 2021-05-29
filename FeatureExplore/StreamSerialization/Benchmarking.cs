#define LargeData
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace StreamSerialization
{
    public class Benchmarking
    {
        private const int DATA_COUNT = 10000;
#if LargeData
        private const int DATA_TO_COMSUME = 8000;
#else
        private const int DATA_TO_COMSUME = 2000;
#endif
        private string serializedString;
        [GlobalSetup]
        public void Setup()
        {
            var random = new Random();
            var data = Enumerable.Range(1, DATA_COUNT)
                .Select((x, index) => new Data
                {
                    Id = x,
                    Value = random.Next().ToString()
                });

            serializedString = JsonSerializer.Serialize(data);
        }

        [Benchmark]
        public void TestDeseriliaze()
        {
            foreach(var item in DeserializeWithoutStreaming().TakeWhile(x => x.Id < DATA_TO_COMSUME))
            {
                // DoSomeWork
            }
        }

        public IEnumerable<Data> DeserializeWithoutStreaming()
        {
            var deserializedData = JsonSerializer.Deserialize<IEnumerable<Data>>(serializedString);
            return deserializedData;
        }

        [Benchmark]
        public async Task TestDeseriliazeAsync()
        {
            foreach (var item in (await DeserializeAsync()).TakeWhile(x => x.Id < DATA_TO_COMSUME))
            {
                // DoSomeWork
            }
        }

        public async Task<IEnumerable<Data>> DeserializeAsync()
        {
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedString));
            var deserializedData = await JsonSerializer.DeserializeAsync<IEnumerable<Data>>(memStream);
            return deserializedData;
        }



        [Benchmark]
        public async Task TestDeserializeAsyncEnumerable()
        {
            await foreach (var item in DeserializeWithStreaming().TakeWhile(x => x.Id < DATA_TO_COMSUME))
            {
                // DoSomeWork
            }
        }

        public async IAsyncEnumerable<Data> DeserializeWithStreaming()
        {
            using var memStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedString));
            await foreach(var item in  JsonSerializer.DeserializeAsyncEnumerable<Data>(memStream))
            {
                yield return item;
            }
        }
    }
}
