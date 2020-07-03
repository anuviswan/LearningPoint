using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class TypePattern<T> : ISwitchExpression<T>, ISwitchStatement<T>
    {
        public string EvaluateSwitchExpression(T criteria) => criteria switch
        {
            Int32 value => $"Type {nameof(Int32)}, Value = {value}",
            Int64 value => $"Type {nameof(Int64)}, Value = {value}",
            string value => $"Type {nameof(String)}, Value = {value}",
            List<int> value when  value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
            List<int> {Count:5 }  value => $"Type Medium {nameof(List<int>)}, Value = {value}",
            List<int> value => $"Type Big {nameof(List<int>)}, Value = {value}",
            null => "Null Detected",
            _ => $"Type Unknown"
        };

        public string EvaluateSwitchStatement(T criteria)
        {
            switch (criteria)
            {
                case Int32 v1 : return $"Type {nameof(Int32)}, Value = {v1}";
                case Int64 v2: return $"Type {nameof(Int64)}, Value = {v2}";
                case string v3: return $"Type {nameof(String)}, Value = {v3}";
                case List<int> v4 when v4.Count < 5: return $"Type Small {nameof(List<int>)}, Value = {v4}";
                case List<int> v5 when v5.Count == 5: return $"Type Medium {nameof(List<int>)}, Value = {v5}";
                case List<int> value: return $"Type Big {nameof(List<int>)}, Value = {value}";
                case null: return "Null Detected";
                default:  return $"Type Unknown";
            }
        }
    }
}
