using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions
{
    interface ISwitchStatement<T>
    {
        string EvaluateSwitchStatement(T criteria);
    }
}
