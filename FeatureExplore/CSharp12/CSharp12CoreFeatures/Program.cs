

var personPrimaryConstructor = new Person("John Doe", 50);
var personExplicitConstructor = new Person("John Doe", "India", 50);

Print("Printing Primary Constructor Demo");
PrintPerson(personPrimaryConstructor);
PrintPerson(personExplicitConstructor);





void Print(string message)
{
    Console.WriteLine(message);
}


// Primary Constructor Examples
void PrintPerson(Person person)
{
    Print("{");
    Print($"{nameof(person.Name)} : '{person.Name}',");
    Print($"{nameof(person.Country)} : '{person.Country}',");
    Print($"{nameof(person.Age)} : {person.Age}");
    Print("}");
}

public class Person(string name,int age)
{
    public Person(string name,string country, int age) : this(name,100)
    {
        Country = country;
    }
    public string Name => name;
    public int Age => age;
    public string Country { get; set; }
}


