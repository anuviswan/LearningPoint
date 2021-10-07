using System;

namespace RxDemo001
{
    class Program
    {
        static void Main(string[] args)
        {
            var observer = new HelloWorldObserver();
            var helloWorldObservable = new HelloWorldObservable();
            helloWorldObservable.Subscribe(observer);
            Console.ReadLine();

        }
    }
}
