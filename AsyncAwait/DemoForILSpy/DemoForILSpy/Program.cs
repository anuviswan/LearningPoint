using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoForILSpy
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Starting {nameof(Main)}");

            // var worker = new Worker();
            var worker = new Worker();
            worker.DoWork();

            while (!worker.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine($"Exiting {nameof(Main)}");
            Console.ReadLine();
        }
    }

    public class Worker
    {
        public bool IsCompleted { get; set; }
        public void DoWork()
        {
            IsCompleted = false;
            Console.WriteLine($"Starting {nameof(DoWork)}");

            ExecuteLongRunningTask();

            Console.WriteLine($"Exiting {nameof(DoWork)}");
            IsCompleted = true;
        }

        public void ExecuteLongRunningTask()
        {
            Console.WriteLine("Doing Some Work");
            Thread.Sleep(1000);
        }

    }


    public class WorkerAsync
    {
        public bool IsCompleted { get; set; }
        public async Task DoWork()
        {
            IsCompleted = false;
            Console.WriteLine($"Starting {nameof(DoWork)}");

            await ExecuteLongRunningTask();

            Console.WriteLine($"Exiting {nameof(DoWork)}");
            IsCompleted = true;
        }

        public Task ExecuteLongRunningTask()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Doing Some Work");
                Thread.Sleep(1000);
            });

        }

    }
}
