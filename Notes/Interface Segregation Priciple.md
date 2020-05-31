Completion of the SOLID series of articles has been due for long time now. The lockdowns due to Covid-19 has atleast given me more time to be able to work one some of the due items.

In this part of the series we will seek to know more about the "I" of *SOLID*, the *Interface Segregation Pricinple (ISP)*. To understand the ISP better, we will begin by visiting a scenario where things have/could go wrong. 

Consider we begin writing code for a Printer. We define the interface as follows

```csharp
public interface IPrinter
{
    void Printer();
    void Scan();
    void Copy();
}

public class AllInOnePrinter:IPrinter
{
    public void Print()
    {

    }
    public void Scan()
    {

    }
    public void Copy()
    {

    }
}

```
This seems perfectly fine when we are considering the All-In-One Printers, but we still got to support the economic printers which do not have Scanners. A implementation of `EconomicPrinter`would look like following

```csharp
public class EconomicPrinter:IPrinter
{
    public void Print()
    {

    }
    public void Scan()
    {
        throw new NotImplementedException();
    }
    public void Copy()
    {
        throw new NotImplementedException();
    }
}
```

The problems with the implementations just stares at our face in the implementation of `EconomicPrinter`. The particular printer which do not support the `Scan()` and `Copy()` functionality is forced to implement the method just because the interface has it. This paves way for possible violation of *Liskov Substition Principle*.

This kind of polluted interface is known as a Fat interface(or interface bloat), where an interface incorporates way too many features, only to find that most the clients do not support all the features.

The problems with Fat interfaces or violations of ISP are more visible in cases where each of the implementation of the interface is in separate assemblies. Now for a change in the interface, each of the assemblies has to be rebuild even if there is no visible change in their functionality.

### Interface Segregation Principle ###

That brings use the definition of Interface Segregation Principle, formally defined as

>“Clients should not be forced to depend upon interfaces that they do not use.”

Quite similiar to the Single Responsibility Principle, the ISP aims to reduce the impact of changes by splitting the responsibilities.

Following the Interface Segregation Principle, we split the `IPrinter` interface into smaller interfaces. For example

```
public interface IPrinter
{
    void Print();
}

public interface ICanScan()
{
    void Scan();
}

public interface ICanCopy()
{
    void Copy();
}
```

Now the `EconomicPrinter` needs to implement only the interface which it provides support for. 

```csharp
public class EconomicPrinter:IPrinter
{
    public void Print()
    {

    }
}
```

While the All-in-One printer can provide all the additional features via the newly defined interfaces.

```csharp
public class AllInOnePrinter:IPrinter,ICanCopy, ICanScan
{
    public void Print()
    {

    }
    public void Scan()
    {

    }
    public void Copy()
    {

    }
}
```

Please note this doesn't mean all the interface should have only one method. No, that is definely not true. The trick lies in understanding the responsibilites of interface and expected behaviors of the Clients.

That is all about ISP. We will delve into the final article on SOLID (Dependency Injection shortly)