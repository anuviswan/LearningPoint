using System;
using System.Reactive.Disposables;

namespace RxDemo001
{
    public class HelloWorldObservable : IObservable<string>
    {
        public IDisposable Subscribe(IObserver<string> observer)
        {
            
            observer.OnNext("Hello");
            observer.OnNext("World!");
            observer.OnNext("This");
            observer.OnNext("is");
            observer.OnNext("a");
            observer.OnNext("Demo");
            observer.OnCompleted();

            return Disposable.Empty;
        }
    }

    public class HelloWorldObserver : IObserver<string>
    {
        public void OnCompleted()
        {
            Console.WriteLine("Completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"Error : {error.Message}");
        }

        public void OnNext(string value)
        {
            Console.Write($"{value} ");
        }
    }

    public static class ObservableDemo
    {
        public static void Run()
        {
            Console.WriteLine($"{nameof(ObservableDemo)} Demo");

            var observer = new HelloWorldObserver();
            var helloWorldObservable = new HelloWorldObservable();
            helloWorldObservable.Subscribe(observer);

            Console.WriteLine();
        }
    }
}
