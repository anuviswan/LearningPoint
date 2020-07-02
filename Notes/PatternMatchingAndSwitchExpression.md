C# 7 introduced us to pattern matching and we have been falling in love with it so much that we do not realize it didn't exist prior to C#. Before we delve into the new patterns introduced in C# 8, Let us take a quick recap of the pattern introduced in C# 7.

- **Type Pattern**

The most common pattern used would be the Type Pattern, which extends the `is` statement to check if the expression matches a type and if so, converts it to particular type.

```csharp
if(input is double val)
{
    // code use val
}
```

- **Const Pattern**

Constant pattern, which follows the pattern matching features of Type Pattern, compares the expression to a constant. For example,

```csharp
if(input is 7m)
{

}
```

or

```
const decimal VALUE = 7m;
if(input is VALUE)
{

}
```

The most common use case of the Constant Pattern is for checking null.

```
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

The var pattern is also useful inside the `switch statement`, epecially when used with a `case guard`. For example,

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

## C# 8: Introducing Switch Expressions

Before we look into other patterns, it would be a good idea introduce one of the finest features of C# 8 - the `switch expressions`.

The `switch expression` introduces a switch like syntax in the context of an expression and provides a clean and concise way for writing `switch` when each each `switch arm` produces a value.

Let us rewrite the `switch statement` in our example of `var pattern` using `swich expression`.

```csharp
private string Evaluate(int input)
{
	var inputCollection = Enumerable.Range(1,100)
                    .Select(x=> Enumerable.Range(x,10)
                                        .Select(c=>c*x));

	return input switch
	{
		5 => "Five",
		4 => "Four",
		var v when inputCollection.Any(x=>x.Contains(v)) => "Collection Contains the value",
		_ => "Not Found"
	};
}
```

As one can observe, the syntax has become more leaner. You do not have to use the repeated `return` statements or `breaks` that associated with `switch statement`.

The syntax has changed ever so slightly. The syntax now ensures the switch arms consists of

- Pattern
- Optional Case Guard
- The `=>` token
- Expression.

The `input` in the `switch expression` is known as _Range Expression_. The noticiable change is how the `switch` keyword now succeeds the _range expression_.

Now that's all only one side of the story. The following patterns which were introduced in C# 8, makes the `switch expressions` even more powerful. Let's go ahead and explore them.

## Value Pattern

The pattern which used in the preceeding example is known as _Value Pattern_, which compares the _range expression_ to a _value_. The _value_ needs to be a compile time constant (of course, case guard can used to evalute arbitary code).

Let's write another example of a Value Pattern for more clarity. For the examples that follows let us use TDD to demonstrate the purpose.

```csharp
public class ValuePatternTests
{
    private IEvaluateExpression<Direction> _evaluator;
    public ValuePatternTests()
    {
        _evaluator = new ValuePattern();
    }
    [Theory]
    [InlineData(Direction.Right,"Direction : Right")]
    [InlineData(Direction.Left,"Direction : Left")]
    [InlineData(Direction.Up,"Direction : Up")]
    [InlineData(Direction.Down,"Direction : Down")]
    public void ValuePatternEvaluate(Direction direction,string expected)
    {
        var result = _evaluator.EvaluateExpression(direction);
        Assert.Equal(expected, result);
    }
}

// Where Direction is defined as
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}
```

As observed from the _xUnit_ test case above, we expect our `EvaluateExpression` method to accept an `Enum` of type `Direction` and return a `string` that represents the enum passed.

Without wasting any time, let us write our desired method.

```csharp
public string EvaluateExpression(Direction criteria) => criteria switch
{
    Direction.Up => $"Direction : {nameof(Direction.Up)}",
    Direction.Down => $"Direction : {nameof(Direction.Down)}",
    Direction.Left => $"Direction : {nameof(Direction.Left)}",
    Direction.Right => $"Direction : {nameof(Direction.Right)}",
};
```

The above code demonstrates how the `switch expression` has made the code more concise and free from boiler plate codes.

## Type Pattern

Type pattern has been already introduced in C# 7, and in this sub section we will see how we could use it within the `switch expression`.
