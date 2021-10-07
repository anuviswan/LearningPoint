using System;

namespace RxDemo001
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableDemo.Run();
            SubjectDemo.Run();
            SubjectWithDelayedSubscribeDemo.Run();
            ReplaySubjectWithDelayedSubscribeDemo.Run();
            ReplaySubjectWithRestrictedCacheDemo.Run();
            ReplaySubjectWithTimeRestrictedCacheDemo.Run();
            BehaviorSubjectWithDelayedSubscribeDemo.Run();
            BehaviorSubjectWithNoCacheDemo.Run();
            BehaviorSubjectSubscribeToCompleted.Run();
            ReplaySubjectSubscribeToCompleted.Run();
            Console.ReadLine();

        }
    }
}
