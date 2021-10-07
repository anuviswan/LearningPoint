using System;
using System.Reactive.Subjects;
using System.Threading;

namespace RxDemo001
{
    public static class SubjectDemo
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

    public static class SubjectWithDelayedSubscribeDemo
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

    public static class ReplaySubjectWithDelayedSubscribeDemo
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


    public static class ReplaySubjectWithRestrictedCacheDemo
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

    public static class ReplaySubjectWithTimeRestrictedCacheDemo
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


    public static class BehaviorSubjectWithDelayedSubscribeDemo
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

    public static class BehaviorSubjectWithNoCacheDemo
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


    public static class BehaviorSubjectSubscribeToCompleted
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

    public static class ReplaySubjectSubscribeToCompleted
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


    public static class AsyncSubjectSubscribeWithoutCompletion
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

    public static class AsyncSubjectSubscribeWithCompletion
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
}
