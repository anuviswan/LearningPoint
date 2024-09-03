using System;

namespace RxDemo001
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableDemo.Run();
            ObservableDemo.RunDemo();
            SubjectDemo.Run();
            SubjectWithDelayedSubscribeDemo.Run();
            ReplaySubjectWithDelayedSubscribeDemo.Run();
            ReplaySubjectWithRestrictedCacheDemo.Run();
            ReplaySubjectWithTimeRestrictedCacheDemo.Run();
            BehaviorSubjectWithDelayedSubscribeDemo.Run();
            BehaviorSubjectWithNoCacheDemo.Run();
            BehaviorSubjectSubscribeToCompleted.Run();
            ReplaySubjectSubscribeToCompleted.Run();
            AsyncSubjectSubscribeWithoutCompletion.Run();
            AsyncSubjectSubscribeWithCompletion.Run();
            SimpleFactoryMethods.Run();
            PropertyNotifyDemo.Run();
            Console.ReadLine();
        }
    }
}
