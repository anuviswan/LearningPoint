using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class PositionalPattern<T> : ISwitchExpression<T> 
    {
        public string EvaluateSwitchExpression(T criteria) => criteria switch
        {
            string { Length : 5 } value  => $"Type {nameof(String)}, Value = {value}",
            List<int> value when value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
            List<int> value when value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
            List<int> value => $"Type Big {nameof(List<int>)}, Value = {value}",
            null => "Null Detected",
            _ => $"Type Unknown"
        };
    }
}
