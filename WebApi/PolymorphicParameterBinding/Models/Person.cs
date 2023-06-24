namespace PolymorphicParameterBinding.Models
{
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } 
    }

    public class Student
    {
        public string SchoolName { get; set; }

    }
}
