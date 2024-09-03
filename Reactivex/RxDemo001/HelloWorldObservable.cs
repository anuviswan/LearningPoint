using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
namespace RxDemo001;
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

    public static void RunDemo()
    {
        Console.WriteLine($"Demo Execution");

        ISubject<int> S = new Subject<int>();
        S.Subscribe(x=> Console.WriteLine(x));

        S.OnNext(1);
        S.OnNext(2);
        S.OnNext(3);
        S.OnNext(4);
    }
}
