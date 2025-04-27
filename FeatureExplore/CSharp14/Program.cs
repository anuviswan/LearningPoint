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

foreach(var items in specialList.Items)
{
    Console.WriteLine(items);
}

Console.WriteLine($"Count: {specialList.Count}");
Console.WriteLine($"IsEmpty: {SpecialList<int>.IsEmpty([1,2,3])}");


// null conditional properties
var nullConditionalAssignment = new NullConditionalAssignment();
nullConditionalAssignment.Assign(10);