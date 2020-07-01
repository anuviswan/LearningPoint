There are some properties that ought to be learned together to understand the complete picture. In this blog post, we will address two of such features.

# Nullable Reference Types

Let us begin by writing some code.

```csharp
public class Foo
{
    public Bar Bar { get; set; }
}

public class Bar
{
    public int Id { get; set; }
}

// Client Code
var foo = new Foo();
Console.WriteLine(foo.Bar.Id);
```

Notice anything wrong ? How often have been guilty of attempting to access something that could potentially be null ? In the above case, we haven't initialized the `Foo.Bar` property, but in the client code, we are attempting to access the `Bar.Id` property.

This would throw a `NullReferenceException`, as you are dereferencing a null value (Bar hasn't been assigned yet). We should have checked for null in the first place.

But as the code base increases, there are times when we forget to do so. And unfortunately, prior to C# 8, there was no way compiler could warn us to do the null check even if we might have wondered many a times if it could do so.

_Nullable Reference Types_ in C# 8 brings us pretty much the same. It allows us to mark the Reference Types which can/cannot be null, using the same syntax we used to mark Nullable Value Types - using the `?` operator.

In C# 8, with Nullable Reference Types enable, if you were to compile the code, the compiler warns you with the following.

```text
Warning	CS8618	Non-nullable property 'Bar' is uninitialized. Consider declaring the property as nullable.
```

Depending on your business logic, you have couple of ways to proceed from here.

**Case 1 - Bar is Nullable**

If your business logic requires that the `Bar` property could be `null`, then you could mark it explicitly. For example,

```csharp
public Bar? Bar { get; set; }
```

The `?` operator tells the compiler that the property could be `null` and it should warn the developer for possible null checks if he hasn't done so yet. The compiler duely warns you with the following.

```text
Warning	CS8602	Dereference of a possibly null reference.
```

**Case 2 - Bar is non-nullable**

If your application logic requires that the `Bar` property cannot be `null`, then you could let the compiler know by using the following syntax (basically omitting the `?` operator).

```csharp
public Bar Bar { get; set; }
```

The above code tells the compiler that the `Bar` cannot be null. Interestingly, we still get a warning now, let us first examine what it is before understanding why compiler throws the warning.

```text
Warning	CS8618	Non-nullable property 'Bar' is uninitialized. Consider declaring the property as nullable.
```

We have declared the property as Non-nullable, yet we have left it uninitialized. We could of course remove this warning by initializing the property with a default value (either in the property declaration or in the constructor), but this gives us an oppurtunity to introduce another feature.

# Null Forgiving Operator

You could have a situation where, as per the business logic, you know that a particular property can never be null at runtime. However, you are in no position to assign a default value. In such situations, you could use the `Null-forgiving` operator to disable the warnings. `Null-Forgiving` is denoted by using the postfix operator `!`. For example,

```csharp
public Bar Bar { get; set; } = null!;
```

The above code informs the compiler that it would skip the warning about Bar being uninitialized and it would not be null in runtime. Do note the `null-forgiving` operator has not runtime influence.

# Null Coalescing Assignment

C# 8 also introduces the Null Coalescing assignment via the the assignment operator `??=`. For demonstration, let us further develop our code and introduce a `CreateBarInstance` to assign instances of Bar. For example,

```csharp
public void CreateBarInstance(Bar instance)
{
    Bar = instance;
}
```

Due to some business reasons, we have requirement that the method should assign `Bar` instance, only if it is null. Of course, one could do this an `if` condition, but that would introduce a lot of boiler plate code. We could eliminate these extraneous code using the null coalescing operator.

```csharp
public void CreateBarInstance(Bar instance)
{
    Bar ??= instance;
}
```

The line `Bar ??= instance` ensures that `Bar` is assigned only when the it is null. Or in other words, the value of `right hand operand` is assigned to `left hand operand` only if the `left hand operand` is null.

Demonstrating the code in action,

```csharp
var foo = new Foo();
foo.CreateBarInstance(new Bar(2));
Console.WriteLine(foo.Bar.Id);
foo.CreateBarInstance(new Bar(3));
Console.WriteLine(foo.Bar.Id);
```

Output of the above code

```text
2
2
```

That's all for now, we will continue our exploration of C# 8 features.
