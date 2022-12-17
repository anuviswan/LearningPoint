using StaticVirtualInterfaceMembers;

Console.WriteLine("Demo code for exploring Static Virtual Members in Interface");
Console.WriteLine($"{nameof(Parrot)}: Can Fly - {Parrot.CanFly()}");
Console.WriteLine($"{nameof(Kiwi)}: Can Fly - {Kiwi.CanFly()}");


//var valGen = new ValGen { Value = 2 };
//for (var i = 0; i < 10; i++)
//    Console.WriteLine(valGen++);


var fibGenOne = new FibGen();

for(var i = 0; i < 10;i++)
    Console.Write($"{fibGenOne++}, ");




