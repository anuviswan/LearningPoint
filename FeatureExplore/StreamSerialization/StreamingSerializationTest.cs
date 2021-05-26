using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StreamSerialization
{
    public class StreamingSerializationTest
    {
        private async IAsyncEnumerable<Data> Generate(int maxItems)
        {
            var random = new Random();
            for (int i = 0; i < maxItems; i++)
            {
                yield return new Data
                {
                    Id = i,
                    Value = random.Next().ToString()
                };
            }
        }

        public async Task SerializeStream()
        {
            using var stream = Console.OpenStandardOutput();
            var data = new { Data = Generate(30) };
            await JsonSerializer.SerializeAsync(stream, data); 
        }

        public async IAsyncEnumerable<T> DeserializeStreaming<T>(string data)
        {
            using var memStream = new MemoryStream(Encoding.UTF8.GetBytes(data));

            await foreach(var item in JsonSerializer.DeserializeAsyncEnumerable<T>(memStream))
            {
                Console.WriteLine("Inside Deserializing..");
                yield return item;
                await Task.Delay(1000);
            }
        }


    }
}
