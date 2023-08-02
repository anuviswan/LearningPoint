namespace CSharp12CoreFeatures;

public class Person(string name, int age)
{
    public Person(string name, string country, int age) : this(name, 100)
    {
        Country = country;
    }
    public string Name => name;
    public int Age => age;
    public string Country { get; set; }

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


