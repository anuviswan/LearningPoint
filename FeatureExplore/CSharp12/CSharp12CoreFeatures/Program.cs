

using CSharp12CoreFeatures;

var personPrimaryConstructor = new Person("John Doe", 50);
var personExplicitConstructor = new Person("John Doe", "India", 50);

Print("Printing Primary Constructor Demo");
PrintPerson(personPrimaryConstructor);
PrintPerson(personExplicitConstructor);





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

