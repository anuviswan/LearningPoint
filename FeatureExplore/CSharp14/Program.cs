using CSharp14;

Console.WriteLine("Hello C# 14!");

// Example of field backed properties
var field = new Field();
field.Foo = 10;

var specialList = new SpecialList<int>();
specialList.Add(1);
specialList.Add(2);
specialList.Add(4);

// extension members
specialList.Insert(2,3);
specialList.InsertOne(2,3);

foreach(var items in specialList.Items)
{
    Console.WriteLine(items);
}

Console.WriteLine($"Count: {specialList.Count}");
Console.WriteLine($"IsEmpty: {SpecialList<int>.IsEmpty([1,2,3])}");


// null conditional properties
var nullConditionalAssignment = new NullConditionalAssignment();

/*
 * Before C# 14.0, you would have to check for null before assigning a value to a property.
 * 
 * if(nullConditionalAssignment is not null)
 * {
 *      nullConditionalAssignment.DemoProperty = 10;
 *      nullConditionalAssignment.DemoEvent += (sender, e) => Console.WriteLine("Event triggered!");
 * }
 * 
 */

// With C# 14.0, you can use the null conditional assignment to simplify the code.

nullConditionalAssignment.Assign(10);
nullConditionalAssignment?.DemoEvent += (sender, e) => Console.WriteLine("Event triggered!");