Caliburn Micro has made a name for itself as one of the easiest to use MVVM Framework around. Caliburn Micro comes in with its own build-in service locator, under the IoC class. This class primarly consists of two static methods, `IoC.Get<T>` and `IoC.GetInstance`, which allows you to access IoC container from any where in code as follows.

```csharp
var instance = IoC.Get<LogService>();
var instance = IoC.GetInstance(typeof(LogService),null);
```

As one can observe from the code above, these two methods comes across as extremely handy methods for the developer.

Having said so, one of the questions that frequently arises is how do you test a method which consists of either of the above two method calls. To explain the scenario better, let us write a sample method, for which we would write our unit tests. 


```csharp
public class SampleClass
{
    public double GetResult(IEnumerable<double> data)
    {
        var sampleService = IoC.Get<SampleService>();
        var result = sampleService.ProcessResult(data);
        // Do further processing
        return finalResult;
    }
}
```

The best way to proceed writing Unit Test would be to let the IoC create instance of `SampleService` via Dependency Injection. However, for the sake of example, let us assume we do not have luxury of making changes to `GetResult` code. Our sample Unit Test would look like as follows

```csharp
[Test]
public void GetResultRandomInput()
{
    var expectedResult = 25;
    var sampleClass = new SampleClass();
    var actualResult = sampleClass.GetResult(Enumerable.Range(1,10));
    Assert.AreEqual(expectedResult,actualResult);
}
```

With the restriction in hand, we now have to figure out a way to mock the `IoC.Get<T>` method. Let us examine the `IoC.Get<T>` source code first.

```csharp
public static T Get<T>(string key = null)
{
    return (T)GetInstance(typeof(T), key);
}
```

As you can observe, the `IoC.Get<T>` method internally calls the `IoC.GetInstance` method. We will advance to observe the `IoC.GetInstance` method now. Let us begin by looking at the signature.

```csharp
public static Func<Type, string, object> GetInstance;
```

`GetInstance` is Func of type `Func<Type,string,object>` and the trick to mock the `IoC.Get<T>` would be to override the `IoC.GetInstance` in the Unit Tests. Let us write some sample code.

```csharp
Caliburn.Micro.IoC.GetInstance = (type, _) =>
{
    if (type == typeof(SampleService))
    {
        return SampleService
        {
            // Initialize properties
        };
    }
    
    return new Exception("Type not registered with IoC");
};
```