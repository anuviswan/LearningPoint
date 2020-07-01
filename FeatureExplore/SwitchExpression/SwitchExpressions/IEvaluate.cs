using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions
{
    public interface IEvaluate<T>
    {
        string Evaluate(T criteria);
    }
}
