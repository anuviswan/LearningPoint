using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    interface ISwitchStatement<T>
    {
        string EvaluateSwitchStatement(T criteria);
    }
}
