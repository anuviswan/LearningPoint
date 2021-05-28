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
        private const int DATA_TO_CONSUME_LOWER = 1000;
        private const int DATA_TO_CONSUME_HIGHER = 8000;
        private string serializedString;
        private readonly Consumer consumer = new Consumer();
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
        public void TestDeseriliazeWithoutStreaming_Lower()
        {
            foreach(var item in DeserializeWithoutStreaming().TakeWhile(x => x.Id < DATA_TO_CONSUME_LOWER))
            {

            }
        }

        [Benchmark]
        public void TestDeseriliazeWithoutStreaming_Higher()
        {
            foreach (var item in DeserializeWithoutStreaming().TakeWhile(x => x.Id < DATA_TO_CONSUME_HIGHER))
            {

            }
        }


        public IEnumerable<Data> DeserializeWithoutStreaming()
        {
            var deserializedData = JsonSerializer.Deserialize<IEnumerable<Data>>(serializedString);
            return deserializedData;
        }

        [Benchmark]
        public async Task TestDeseriliazeAsync_Lower()
        {
            foreach (var item in (await DeserializeAsync()).TakeWhile(x => x.Id < DATA_TO_CONSUME_LOWER))
            {

            }
        }

        [Benchmark]
        public async Task TestDeseriliazeAsync_Higher()
        {
            foreach (var item in (await DeserializeAsync()).TakeWhile(x => x.Id < DATA_TO_CONSUME_HIGHER))
            {

            }
        }
        public async Task<IEnumerable<Data>> DeserializeAsync()
        {
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedString));
            var deserializedData = await JsonSerializer.DeserializeAsync<IEnumerable<Data>>(memStream);
            return deserializedData;
        }



        [Benchmark]
        public async Task TestDeseriliazeWithStreaming_Lower()
        {
            await foreach (var item in DeserializeWithStreaming().TakeWhile(x => x.Id < DATA_TO_CONSUME_LOWER))
            {

            }
        }

        [Benchmark]
        public async Task TestDeseriliazeWithStreaming_Higher()
        {
            await foreach (var item in DeserializeWithStreaming().TakeWhile(x => x.Id < DATA_TO_CONSUME_HIGHER))
            {

            }
        }

        public IAsyncEnumerable<Data> DeserializeWithStreaming()
        {
            var memStream = new MemoryStream(Encoding.UTF8.GetBytes(serializedString));
            var deserializedData = JsonSerializer.DeserializeAsyncEnumerable<Data>(memStream);
            return deserializedData;
        }
    }
}
