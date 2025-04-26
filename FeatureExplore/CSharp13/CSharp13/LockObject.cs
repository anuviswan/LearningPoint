using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;

namespace CSharp13;

internal class LockObject
{


    private int counter = 0;
    private readonly object _traditionalLockObject = new();
    private ConcurrentQueue<int> _queue = new();
    public void DemoTraditionalApproach()
    {
        lock (_traditionalLockObject)
        {
            counter++;
        }
    }

    private readonly Lock _ModernlockObject = new();
    public void DemoModernApproach() 
    {
        lock (_ModernlockObject)
        {
            counter++;
            _queue.Enqueue(counter);
        }
    }
}

[MemoryDiagnoser]
public class BenchMarkLockObject
{
    [Params(1,3,5 ,10, 100, 1000)]
    public int Counter { get; set; }

    [Benchmark]
    public void TraditionalApproach()
    {
        var lockObject = new LockObject();
        Parallel.For(1, Counter,_ =>
        {
            lockObject.DemoTraditionalApproach();
        });
    }

    [Benchmark]
    public void ModernApproach()
    {
        var lockObject = new LockObject();
        Parallel.For(1, Counter, _ =>
        {
            lockObject.DemoModernApproach();
        });
    }
}
