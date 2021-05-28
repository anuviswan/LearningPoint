#define BENCHMARK
using System;
using System.Threading.Tasks;

namespace StreamSerialization
{
    class Program
    {
        static async Task Main(string[] args)
        {
#if (BENCHMARK)
            RunBenchmarkTests();
#else
            await RunDemo();
#endif
        }


        static void RunBenchmarkTests()
        {
            BenchmarkDotNet.Running.BenchmarkRunner.Run<Benchmarking>();
        }

        static async Task RunDemo()
        {
            Console.WriteLine("Streaming Deserialize Demo");
            var dataString = "[{\"Id\":0,\"Value\":\"915777539\"},{\"Id\":1,\"Value\":\"1332243482\"},{\"Id\":2,\"Value\":\"306207588\"},{\"Id\":3,\"Value\":\"1413388423\"},{\"Id\":4,\"Value\":\"2145941621\"},{\"Id\":5,\"Value\":\"1041779876\"},{\"Id\":6,\"Value\":\"1121436961\"},{\"Id\":7,\"Value\":\"520045044\"},{\"Id\":8,\"Value\":\"1357859915\"},{\"Id\":9,\"Value\":\"1340510964\"},{\"Id\":10,\"Value\":\"1183306988\"},{\"Id\":11,\"Value\":\"502467538\"},{\"Id\":12,\"Value\":\"31513434\"},{\"Id\":13,\"Value\":\"999086707\"},{\"Id\":14,\"Value\":\"961728759\"},{\"Id\":15,\"Value\":\"1756662810\"},{\"Id\":16,\"Value\":\"1018107007\"},{\"Id\":17,\"Value\":\"433502262\"},{\"Id\":18,\"Value\":\"1784715926\"},{\"Id\":19,\"Value\":\"1418088822\"},{\"Id\":20,\"Value\":\"645106286\"},{\"Id\":21,\"Value\":\"1720929044\"},{\"Id\":22,\"Value\":\"1102142546\"},{\"Id\":23,\"Value\":\"2138442183\"},{\"Id\":24,\"Value\":\"208176799\"},{\"Id\":25,\"Value\":\"1700100438\"},{\"Id\":26,\"Value\":\"769308703\"},{\"Id\":27,\"Value\":\"1558581057\"},{\"Id\":28,\"Value\":\"352810944\"},{\"Id\":29,\"Value\":\"299925316\"}]";

            var instance = new StreamingSerializationTest();
            await foreach (var item in instance.DeserializeStreaming<Data>(dataString))
            {
                Console.WriteLine($"Data Item: {nameof(Data.Id)}={item.Id} , {nameof(Data.Value)}={item.Value}");

                if (item.Id > 5)
                {
                    break;
                }
            }

            Console.WriteLine("Streaming Serialiaze Demo");

            var task = Task.Run(() => instance.SerializeStream());
            task.Wait();
        }
    }
}
