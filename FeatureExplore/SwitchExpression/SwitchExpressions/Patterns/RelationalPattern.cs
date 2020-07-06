using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class RelationalPattern : ISwitchExpression<Person>
    {
        public string EvaluateSwitchExpression(Person criteria) => throw new NotImplementedException();
    }
}
