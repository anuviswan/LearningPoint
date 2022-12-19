using StaticVirtualInterfaceMembers;

Console.WriteLine("Demo code for exploring Static Virtual Members in Interface");
Console.WriteLine($"{nameof(Parrot)}: Can Fly - {Parrot.CanFly()}");
Console.WriteLine($"{nameof(Kiwi)}: Can Fly - {Kiwi.CanFly()}");


IBar bar = new Bar();
Console.WriteLine($"Bar.GetName() == {bar.GetName()}");

IBar fooBar = new FooBar();
Console.WriteLine($"FooBar.GetName() == {fooBar.GetName()}");

//var valGen = new ValGen { Value = 2 };
//for (var i = 0; i < 10; i++)
//    Console.WriteLine(valGen++);


var fibGenOne = new FibonacciGenerator();

for(var i = 0; i < 10;i++)
    Console.Write($"{fibGenOne++}, ");




