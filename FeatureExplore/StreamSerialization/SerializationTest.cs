using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace StreamSerialization
{
    public class SerializationTest
    {
        private async IAsyncEnumerable<int> Generate(int maxItems)
        {
            for (int i = 0; i < maxItems; i++)
            {
                yield return i;
                await Task.Delay(1000);
            }
        }

        public async Task SerializeStream()
        {
            var stream = Console.OpenStandardOutput();
            var data = new { Data = Generate(3000) };
            await JsonSerializer.SerializeAsync(stream, data); // prints {"Data":[0,1,2]} 
        }
    }
}
