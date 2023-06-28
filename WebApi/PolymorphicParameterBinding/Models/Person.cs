namespace PolymorphicParameterBinding.Models
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string EntityType { get; set; }
    }

    public class Employee:Person
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } 
    }

    public class Student:Person
    {
        public string SchoolName { get; set; }

    }
}
