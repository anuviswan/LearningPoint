using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution.PostConditions
{
    public class School
    {
        public virtual decimal CalculateLabFees(long studentId)
        {
            var labFee = MockMethodForCalculatingLabFees(studentId);

            if (labFee <= 0)
                return 1000;
            return labFee;
        }

        private decimal MockMethodForCalculatingLabFees(long studentID)
        {
            return default;
        }
    }


    public class Kindergarden : School
    {
        public override decimal CalculateLabFees(long studentId)
        {
            return 0;
        }
    }
}
