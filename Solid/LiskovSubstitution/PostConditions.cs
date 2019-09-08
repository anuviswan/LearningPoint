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
            return 1000;
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
