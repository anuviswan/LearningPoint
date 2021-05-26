using System;
using System.Threading.Tasks;

namespace StreamSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = new SerializationTest();
            var task = Task.Run(()=> instance.SerializeStream());
            task.Wait();
        }
    }
}
