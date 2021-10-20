using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace RxDemo001;
public class SimpleFactoryMethods:IExecute
{
    public static void Run()
    {
        Console.WriteLine("Executing Simple Factory");
        Execute(nameof(Observable.Return), ()=>ExecuteReturn());
        Execute(nameof(Observable.Create), ()=> ExecuteReturnWithObservableCreate());
    }

    public static void Execute(string message,Action action)
    {
        Console.WriteLine(message);
        action();
    }

    private static void ExecuteReturn()
    {
        Observable.Return("Anu").Subscribe(Console.WriteLine);
    }

    private static void ExecuteReturnWithObservableCreate()
    {
        Observable.Create<string>(o =>
        {
            o.OnNext("Anu");
            o.OnCompleted();
            return Disposable.Empty;
        }).Subscribe(Console.WriteLine);
    }

}
