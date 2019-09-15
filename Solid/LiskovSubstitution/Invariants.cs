using System;

namespace LiskovSubstitution.Invariants
{
    public class Student
    {
        public string Name{ get; set; }

        public void CheckInvariants()
        {
            if (string.IsNullOrEmpty(Name))
                Name = "Name Not Assigned";
        }
        public virtual void AssignName(string name)
        {
            CheckInvariants();
            Name = name;
            CheckInvariants();
        }
    }

    public class NurseryStudent : Student
    {
        public override void AssignName(string name)
        {
            Name = name;
        }

    }
}
