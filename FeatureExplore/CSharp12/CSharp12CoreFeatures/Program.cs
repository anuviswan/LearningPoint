
using CSharp12CoreFeatures;

Print("Primary Constructor Demo");
var personPrimaryConstructor = new Person("John Doe", 50);
var personExplicitConstructor = new Person("John Doe", "India", 50);

Print("Printing Primary Constructor Demo");
PrintPerson(personPrimaryConstructor);
PrintPerson(personExplicitConstructor);

Print("Mutating Primary Constructor parameters");
personPrimaryConstructor.AssignNameAndAge("Jane Doe",100);
PrintPerson(personPrimaryConstructor);


Print("Collection Expression Dmeo");
var collectionExpressionDemo = new CollectionExpressionsDemo();
collectionExpressionDemo.PrintEmployeeCount();

Print("Printing Directors WorldWide");
foreach(var director in collectionExpressionDemo.DirectorsWorldWide)
{
    Print(director);
}


Print("Inline Array Demno");
var inlineArrayDemo = new InlineArrayDemo();
inlineArrayDemo.Create([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
inlineArrayDemo.Print();



void Print(string message)
{
    Console.WriteLine(message);
}

void PrintPerson(Person person)
{
    Print("{");
    Print($"{nameof(person.Name)} : '{person.Name}',");
    Print($"{nameof(person.Country)} : '{person.Country}',");
    Print($"{nameof(person.Age)} : {person.Age}");
    Print("}");
}

