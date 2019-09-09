using System;

namespace LiskovSubstitution.Invariants
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student()
        {

        }
        public Student(string name,int age)
        {
            if (Age < 5)
                throw new Exception("Age should be higher than 5");

            Name = name;
            Age = age;
        }
    }

    public class NurseryStudent : Student
    {
        public NurseryStudent(string name, int age)//:base(name,age)
        {
            Age = age;
            Name = name;
        }
        
    }
}
