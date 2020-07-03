C# 7 introduced us to pattern matching and we have been falling in love with it so much that we do not realize it didn't exist prior to C#. Before we delve into the new patterns introduced in C# 8, Let us take a quick recap of the pattern introduced in C# 7.

- **Const Pattern**

Constant pattern, extends the `is` statement to compare the expression to a constant. For example,

```csharp
if(input is 7m)
{

}
```

or

```csharp
const decimal VALUE = 7m;
if(input is VALUE)
{

}
```

The most common use case of the Constant Pattern is for checking null.

```csharp
if(input is null)
{

}
```

- **var Pattern**

Probably the least used of among the 3 patterns introduced in C# 7 is the `var` pattern. The var pattern is unique in its own way. It always succeeds.

So what would be the use-case for something which always succeeds ? Since the pattern always succeeds and the value is assigned to the variable, you could use the `var` pattern to create a temporary variable.

This is especially useful inside a linq query where you could create a temporary variable inside a `where` condition . For example,

```csharp
var inputCollection = Enumerable.Range(1,100)
                    .Select(x=> Enumerable.Range(x,10)
                                        .Select(c=>c*x));
var result = inputCollection.Where(x=> x.ToList() is var list
                                && list.Average() > 100);
```

The var pattern is also useful inside the `switch statement`, especially when used with a `case guard`. For example,

```csharp
private string Evaluate(int input)
{
	var inputCollection = Enumerable.Range(1,100)
                    .Select(x=> Enumerable.Range(x,10)
                                        .Select(c=>c*x));
	switch(input)
	{
		case 5:
			return "Five";
		case 4:
			return "Six";
		case var v when inputCollection.Any(x=>x.Contains(v)):
			return "Collection Contains the value";
		default :
			return "Not Found";
	}
}
```

- **Type Pattern**

The most common pattern used would be the Type Pattern, which checks if the expression matches a type and if so, converts it to particular type.

```csharp
if(input is double val)
{
    // code use val
}
```

Type pattern could also be used within a `Switch Statement`. For example,

```csharp
public string EvaluateSwitchStatement(T criteria)
{
    switch (criteria)
    {
        case Int32 value : return $"Type {nameof(Int32)}, Value = {value}";
        case Int64 value: return $"Type {nameof(Int64)}, Value = {value}";
        case string value: return $"Type {nameof(String)}, Value = {value}";
        case List<int> value when value.Count < 5: return $"Type Small {nameof(List<int>)}, Value = {value}";
        case List<int> value when value.Count == 5: return $"Type Medium {nameof(List<int>)}, Value = {value}";
        case List<int> value: return $"Type Big {nameof(List<int>)}, Value = {value}";
        case null: return "Null Detected";
        default:  return $"Type Unknown";
    }
}

```

As one can observe, the patterns has made the _switch statements_ whole the more powerful. However, there is a lot of boiler plate code going around. You would wish to do away with the repeated `case` and `return`/`breaks`;

## Introducing Switch Expressions

Before we look into other patterns, it would be a good idea introduce one of the finest features of C# 8 - the _switch expressions_.

The _switch expression_ introduces a switch like syntax in the context of an expression and provides a clean and concise way for writing `switch` when each each _switch arm_ produces a value.

Let us rewrite the _switch statement_ in our example of `type pattern` using _swich expression_.

```csharp
public string EvaluateSwitchExpression(T criteria) => criteria switch
{
    Int32 value => $"Type {nameof(Int32)}, Value = {value}",
    Int64 value => $"Type {nameof(Int64)}, Value = {value}",
    string value => $"Type {nameof(String)}, Value = {value}",
    List<int> value when  value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
    List<int> value when value.Count == 5 =>  value => $"Type Medium {nameof(List<int>)}, Value = {value}",
    List<int> value => $"Type Big {nameof(List<int>)}, Value = {value}",
    null => "Null Detected",
    _ => $"Type Unknown"
};
```

As one can observe, the syntax has become more leaner. You do not have to use the repeated `return` statements or `breaks` that associated with _switch statement_.

The syntax has changed ever so slightly. The syntax now ensures the switch arms consists of

- Pattern
- Optional Case Guard
- The `=>` token
- Expression.

The `criteria` in the _switch expression_ is known as _Range Expression_. The noticiable change is how the `switch` keyword now succeeds the _range expression_.

The code above also introduces the `discard pattern`. Discard pattern `-` matches all expressions and is used to matching the `default` in switch expression. And since it match all expression, it needs to be appear at the very end of the _switch expression_.

Now that's all only one side of the story. The following patterns which were introduced in C# 8, makes the _switch expressions_ even more powerful. Let's go ahead and explore them.

## Property Pattern.

The _property pattern_ enables you to check if the given value is `null` and match the public properties on the object. For example,

```csharp
public class Foo
{
	public string FirstName {get;set;}
	public string LastName {get;set;}
}

var foo = new Foo {FirstName = "Anu", LastName="Viswan"};
if(foo is Foo {FirstName:"Anu",LastName:"Viswan"})
{
   // code
}
```

The _property pattern_ allows to check if `Foo.FirstName` and `Foo.LastName` matches the desired values. Compare this lean syntax against the conventional syntax which existed before the patterns were introduced.

```csharp
if(foo is Foo && foo.FirstName=="Anu" && foo.LastName=="Viswan")
{
    // code
}
```

As evident from the code abvoe, _property pattern_ has made the code more concise.

We could use the _property pattern_ in our preceeding example of switch expression to trim down it further.

```csharp
public string EvaluateSwitchExpression(T criteria) => criteria switch
{
    Int32 value => $"Type {nameof(Int32)}, Value = {value}",
    Int64 value => $"Type {nameof(Int64)}, Value = {value}",
    string value => $"Type {nameof(String)}, Value = {value}",
    List<int> value when  value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
    List<int> {Count:5 }  value => $"Type Medium {nameof(List<int>)}, Value = {value}",
    List<int> value => $"Type Big {nameof(List<int>)}, Value = {value}",
    null => "Null Detected",
    _ => $"Type Unknown"
};
```

The highlighted expression has been made more consise eliminating the _case guard_, instead using the _property pattern_. Let us explore one more case of _property pattern_ where the pattern is exclusively used.

```csharp
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

public string EvaluateSwitchExpression(Person criteria) => criteria switch
{
    { FirstName: "Anu", Age: 36 } => "FirstName and Age Matched",
    { LastName: "Viswan" } person when person.Age < 40 => "LastName With Age Less than Matched",
    { LastName: "Doe" } => "LastName Matched",
    _ => "Not Found"
};
```

Compare this with the conventional _switch statement_ approach.

```csharp
public string EvaluateSwitchStatement(Person criteria)
{
    switch (criteria)
    {
        case var person when person.FirstName.Equals("Anu") && person.Age == 36:
            return "FirstName and Age Matched";
        case var person when person.LastName.Equals("Viswan") && person.Age < 40:
            return "LastName With Age Less than Matched";
        case var person when person.LastName.Equals("Doe"):
            return "LastName Matched";
        default:
            return "Not Found";
    };
}
```

Once again, the _switch expression_ has managed to beat the _switch statement_ hands down in terms of clarity and leaner code.
