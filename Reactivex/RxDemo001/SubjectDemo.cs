using System;
using System.Reactive.Subjects;
using System.Threading;

namespace RxDemo001;
public class SubjectDemo : IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(SubjectDemo)} Demo");

        var subject = new Subject<int>();
        subject.Subscribe(Console.Write);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}

public class SubjectWithDelayedSubscribeDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(SubjectWithDelayedSubscribeDemo)} Demo");

        var subject = new Subject<int>();
        subject.OnNext(1);
        subject.OnNext(2);
        subject.Subscribe(Console.Write);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}

public class ReplaySubjectWithDelayedSubscribeDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(ReplaySubjectWithDelayedSubscribeDemo)} Demo");

        var subject = new ReplaySubject<int>();
        subject.OnNext(1);
        subject.OnNext(2);
        subject.Subscribe(Console.Write);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}


public class ReplaySubjectWithRestrictedCacheDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(ReplaySubjectWithRestrictedCacheDemo)} Demo");

        var subject = new ReplaySubject<int>(1);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.Subscribe(Console.Write);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}

public class ReplaySubjectWithTimeRestrictedCacheDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(ReplaySubjectWithTimeRestrictedCacheDemo)} Demo");

        var subject = new ReplaySubject<int>(TimeSpan.FromMilliseconds(1000));
        subject.OnNext(1);
        Thread.Sleep(500);
        subject.OnNext(2);
        Thread.Sleep(200);
        subject.OnNext(3);
        Thread.Sleep(500);
        subject.Subscribe(Console.Write);
        subject.OnNext(4);
        Thread.Sleep(500);

        Console.WriteLine();
    }
}


public class BehaviorSubjectWithDelayedSubscribeDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(BehaviorSubjectWithDelayedSubscribeDemo)} Demo");

        var subject = new BehaviorSubject<int>(0);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.Subscribe(Console.Write);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}

public class BehaviorSubjectWithNoCacheDemo:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(BehaviorSubjectWithNoCacheDemo)} Demo");

        var subject = new BehaviorSubject<int>(0);
        subject.Subscribe(Console.Write);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);

        Console.WriteLine();
    }
}


public class BehaviorSubjectSubscribeToCompleted:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(BehaviorSubjectSubscribeToCompleted)} Demo");

        var subject = new BehaviorSubject<int>(0);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);
        subject.OnCompleted();
        subject.Subscribe(Console.Write);
        Console.WriteLine();
    }
}

public class ReplaySubjectSubscribeToCompleted:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(ReplaySubjectSubscribeToCompleted)} Demo");

        var subject = new ReplaySubject<int>(1);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);
        subject.OnCompleted();
        subject.Subscribe(Console.Write);
        Console.WriteLine();
    }
}


public class AsyncSubjectSubscribeWithoutCompletion:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(AsyncSubjectSubscribeWithoutCompletion)} Demo");

        var subject = new AsyncSubject<int>();
        subject.Subscribe(Console.Write);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);
        Console.WriteLine();
    }
}

public class AsyncSubjectSubscribeWithCompletion:IExecute
{
    public static void Run()
    {
        Console.WriteLine($"{nameof(AsyncSubjectSubscribeWithCompletion)} Demo");

        var subject = new AsyncSubject<int>();
        subject.Subscribe(Console.Write);
        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);
        subject.OnNext(4);
        subject.OnCompleted();
        Console.WriteLine();
    }
}
