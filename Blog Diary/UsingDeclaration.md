The next feature we would explore in C# 8 is more off a syntatic sugar, but neverthless it is important to understand the difference between the new syntax and the original feature it is covering up. We are all aware of the `Using` statements, which allows correct usage of the `IDisposible` objects. 

### Using Statement ###

Let us begin by writing an example with the Old way of doing things. We will first introduce our Custom Object with IDisposible implemented.

```csharp
public interface ITalk
{
    void Talk(string message);
}

public class CustomDisposibleObject : IDisposable,ITalk
{
    public void Dispose()
    {
        Console.WriteLine($"Disposing {nameof(CustomDisposibleObject)}");
    }

    public void Talk(string message)
    {
        Console.WriteLine($"{nameof(CustomDisposibleObject)}-{nameof(ITalk.Talk)} : {message}");
    }
}


```

We will now use CustomDisposibleObject with the Using Statement.

```csharp
public int UsingStatement()
{
    using (var customDisposibleObject = new CustomDisposibleObject())
    {
        customDisposibleObject.Talk(nameof(IExample.UsingStatement));
        return default;
    }
}
```


The `Using` statement is of course a syntatic sugar over the Try-Finally block. The compiler translates the above code as (check using Telerik's JustDecompile)

```csharp
public int UsingStatement()
{
    int num;
    CustomDisposibleObject customDisposibleObject = new CustomDisposibleObject();
    try
    {
        customDisposibleObject.Talk("UsingStatement");
        num = 0;
    }
    finally
    {
        if (customDisposibleObject != null)
        {
            customDisposibleObject.Dispose();
        }
    }
    return num;
}
```


So far, so good. So what is the real problem with the Using Statement and why would one introduce the Using Declaration. To begin with, the Using Statement syntax is way too verbose and breaks the normal flow of syntax. This is where the Using Declaration comes into picture.

### Using Declaration ###

The Using Declaration Sytax removes much of the ceremony associated with the Using Statement blocks. For example, if one were rewrite the above code via the new Using Declaration.

```csharp
public int UsingDeclaration()
{
    using var customDisposibleObject = new CustomDisposibleObject();
    customDisposibleObject.Talk(nameof(IExample.UsingDeclaration));
    return default;
}
```
The cerimonial braces are now gone and the code look less verbose. The obvious question would be  - When is the object disposed ? 

The object is disposed when it leaves the scope, which in the case of the code above is the method. 

So how does the new syntax gets translated by the compiler ? Let us rerun the JustDecompile and check it.

``` csharp
public int UsingDeclaration()
{
    int num;
    CustomDisposibleObject customDisposibleObject = new CustomDisposibleObject();
    try
    {
        customDisposibleObject.Talk("UsingDeclaration");
        num = 0;
    }
    finally
    {
        if (customDisposibleObject != null)
        {
            customDisposibleObject.Dispose();
        }
    }
    return num;
}
```

As you can observe, there is no difference at all. The new syntax removes the cerimonial braces, making the code *look* less nested.

Sample Code for this article could be found in my [Github](https://github.com/anuviswan/LearningPoint/tree/master/FeatureExplore/UsingDeclaration).