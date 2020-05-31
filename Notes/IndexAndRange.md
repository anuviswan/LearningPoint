While C# as a language has grown leaps and bounds, one are that was least addressed was manipulation of collections (arrays in particular). C# 8 looks to change exactly that by introducing two new Types.

**System.Index**

*System.Index* is a structure that can be used to Index a collection either from the start or the end. In previous versions of the language, there was no direct way to index a collection from the end. For example,

``` csharp
// Get the 2nd element from end in the array
var secondElementFromLast = arr[arr.Length-2];
```

This changes with introduction of the *System.Index*, which fortunately is introduced with its own syntatic sugar. The code above, for accessing the second last element could be now rewritten as

```csharp
// Get the 2nd element from end in the array
var secondElementFromLast = arr[^2]; // With the uniary prefix 'hat' operator
```
To access the elements from the begining of the array, you could use
```csharp
// Get 2nd element from the start in the array
var secondElementFromStart = arr[2]; // No changes here
```

**System.Range**

In previous versions of C#, there was no easy way to get a slice of the collection. Let's say, you wanted to get all elements from 2nd to 5th element in the array. You could achieve this using Linq using the Enumerable.Skip and Enumerable.Take methods. For example

``` csharp
var slice = list.Skip(1).Take(4);
```

C# 8.0 introduces the *System.Range* type, again with support of syntatic sugar to ease the life of developers. The above code could now be rewritten as

``` csharp
var slice = list[1..5];
```

The Range Structure represents range that has a start and end indexes and is represented by binary infix `x..y`. Do note that both operands of the range could be ommited to provide different meanings. For example
```
var slice1 = list[5..]; // All elements starting from the 5th element in collection
var slice2 = list[..5]; // First 5 elements in collection
var slice3 = list[..^5]; // Elements starting from first till the 5th element from last
var slice4 = list[^5..]; // Last 5 elements in collection
var slice5 = list[..]; // Entire List
```

We will continue exploring newer features of the language in coming blog posts.