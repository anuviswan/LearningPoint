// See https://aka.ms/new-console-template for more information
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Demo code for 'required' modifier");

// Will raise compile time errors
 // var foo = new Foo(); 

// Compiles
var foo = new Foo() { Name = "John Doe" };  


// Compiles
//var bar = new Bar();

// This will throw error as initialization is done using a constructor 
// which does not have the SetsRequiredMembers Attribute
 var bar = new Bar("John Doe"); 

public class Foo
{
    public required string  Name{ get; init; }
}


public class Bar
{
    [SetsRequiredMembers]
    public Bar() => Name = String.Empty;

    public Bar(string name) => Name = name;
    public required string Name{ get; set; }
}
