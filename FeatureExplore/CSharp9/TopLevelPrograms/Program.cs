using static System.Console;
WriteLine($"Hello {GetName()}");
WriteLine($"Hello {new Foo().GetName()}");

string GetName() => "Anu Viswan";
class Foo
{
    public string GetName() => "Anu Viswan";
}