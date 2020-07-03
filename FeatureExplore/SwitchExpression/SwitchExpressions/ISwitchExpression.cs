using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions
{
    public interface ISwitchExpression<T>
    {
        string EvaluateSwitchExpression(T criteria);
    }
}
