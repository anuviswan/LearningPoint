using StaticVirtualInterfaceMembers;

Console.WriteLine("Demo code for exploring Static Virtual Members in Interface");
Console.WriteLine($"{nameof(Parrot)}: Can Fly - {Parrot.CanFly()}");
Console.WriteLine($"{nameof(Kiwi)}: Can Fly - {Kiwi.CanFly()}");
var parrot = new Parrot();


var fooBar = Apple.CreateInstance();
fooBar.SayHello();

CustomNumber customNumber1 = new() { Value = 1 };
CustomNumber customNumber2 = new() { Value = 3 };

Console.WriteLine($"Average : {INumeric<CustomNumber>.Average(customNumber1, customNumber2)}");



//var valGen = new ValGen { Value = 2 };
//for (var i = 0; i < 10; i++)
//    Console.WriteLine(valGen++);


var fibGenerator = FibonacciGenerator.Zero;

for(var i = 0; i < 10;i++)
    Console.Write($"{fibGenerator++}, ");




