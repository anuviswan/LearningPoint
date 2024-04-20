namespace CSharp12CoreFeatures;


public class FooWithoutPrimaryConstructor
{
    public string Name { get; init; }
    public string Address { get; init; }


    public FooWithoutPrimaryConstructor(string name,string address)
    {
        Name = name;
        Address = address;
    }
}

// Primary Constructor eliminates the need for explicit constructor,
// with sole purpose of assigning values to private fields/properties
public class FooWithPrimaryConstructor(string name, string address)
{
    public string Name { get; init; } = name;
    public string Address { get; init; } = address;
}



public class Person(string name, int age)
{
    // Explicit Constructor 'should' invoke Primary Constructor
    public Person(string name, string country, int age) : this(name, 100)
    {
        Country = country;
    }
    public string Name => name;
    public int Age => age;
    public string Country { get; set; }

    // Mutating Primary Constructor Variables
    public void AssignNameAndAge(string newName,int newAge)
    {
        name = newName;
        age = newAge;
    }
}

public class Employee(string firstName, string lastName, int age) : Person($"{firstName} {lastName}", age)
{
    public string Department { get; set; }
}

