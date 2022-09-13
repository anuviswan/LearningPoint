// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Demo code for 'required' modifier");

// var foo = new Foo(); // This would throw error
var foo = new Foo() { Name = "John Doe" };
//var bar = new Bar() { Name = "John Doe" };
// var bar = new Bar();  // This will not throw error


public class Foo
{
    public required string  Name{ get; init; }
}


public class Bar
{
    [SetsRequiredMembers]
    public Bar() => Name = String.Empty;
    public required string Name{ get; set; }
}
