using System;

namespace LiskovSubstitution
{
    public class School
    {
        public virtual int GetStudentCount(int minAge)
        {
            if (minAge <= 0)
                throw new ArgumentOutOfRangeException("Invalid Age");
            return default; // For demo purpose
        }
    }

    public class Kindergarden : School
    {
        public override int GetStudentCount(int minAge)
        {
            if (minAge <= 0)
                throw new ArgumentOutOfRangeException("Invalid Age");

            if (minAge >= 5)
                throw new ArgumentOutOfRangeException("Invalid Age");
            return default; // For demo purpose
        }
    }
}
