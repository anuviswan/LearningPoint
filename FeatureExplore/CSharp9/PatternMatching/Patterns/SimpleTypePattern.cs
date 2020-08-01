using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Patterns
{
    public class SimpleTypePattern<T> : ISwitchExpression<T>, ISwitchStatement<T>
    {
        public string EvaluateSwitchExpression(T criteria) => criteria switch
        {
            Int32  => $"Type {nameof(Int32)}, Value = {criteria}",
            Int64 value => $"Type {nameof(Int64)}, Value = {value}",
            string value => $"Type {nameof(String)}, Value = {value}",
            List<int> value when value.Count < 5 => $"Type Small {nameof(List<int>)}, Value = {value}",
            List<int> { Count: 5 } value => $"Type Medium {nameof(List<int>)}, Value = {value}",
            List<int> value => $"Type Big {nameof(List<int>)}, Value = {value}",
            null => "Null Detected",
            _ => $"Type Unknown"
        };

        public string EvaluateSwitchStatement(T criteria)
        {
            switch (criteria)
            {
                case Int32 value: return $"Type {nameof(Int32)}, Value = {value}";
                case Int64 value: return $"Type {nameof(Int64)}, Value = {value}";
                case string value: return $"Type {nameof(String)}, Value = {value}";
                case List<int> value when value.Count < 5: return $"Type Small {nameof(List<int>)}, Value = {value}";
                case List<int> value when value.Count == 5: return $"Type Medium {nameof(List<int>)}, Value = {value}";
                case List<int> value: return $"Type Big {nameof(List<int>)}, Value = {value}";
                case null: return "Null Detected";
                default: return $"Type Unknown";
            }
        }
    }
}
