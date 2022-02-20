// See https://aka.ms/new-console-template for more information
using System;
Console.WriteLine("Hello, World!");
Foo(null);

static void Foo(string name)
{
}


public class Bar
{
    [Foo<long>]
    public long Id { get; set; }

    [Foo<string>]
    public string Name { get; set; }

}
public class FooAttribute<T> : Attribute
{

}