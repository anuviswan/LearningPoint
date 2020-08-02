using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching.Patterns
{
    public class LogicalPattern<T> : ISwitchExpression<T>, ISwitchStatement<T>
    {
        public string EvaluateSwitchExpression(T criteria) => criteria switch
        {
            Int32 => $"Type {nameof(Int32)}, Value = {criteria}",
            Int64 => $"Type {nameof(Int64)}, Value = {criteria}",
            String => $"Type {nameof(String)}, Value = {criteria}",
            List<int> value => value.Count switch
            {
                < 5 => $"Type Small {nameof(List<int>)}, Value = {value.Count}",
                > 10 => $"Type Extra Large {nameof(List<int>)}, Value = {value.Count}",
                > 5  and < 10 => $"Type Big {nameof(List<int>)}, Value = {value.Count}",
                _ => $"Type Medium {nameof(List<int>)}, Value = {value.Count}",
            },
            null => "Null Detected",
            not null => $"Type Unknown"
        };

        public string EvaluateSwitchStatement(T criteria)   
        {
            switch (criteria)
            {
                case Int32 value: return $"Type {nameof(Int32)}, Value = {value}";
                case Int64 value: return $"Type {nameof(Int64)}, Value = {value}";
                case string value: return $"Type {nameof(String)}, Value = {value}";
                case List<int> value when value.Count < 5: return $"Type Small {nameof(List<int>)}, Value = {value.Count}";
                case List<int> value when value.Count == 5: return $"Type Medium {nameof(List<int>)}, Value = {value.Count}";
                case List<int> value when value.Count >5 && value.Count < 10: return $"Type Big {nameof(List<int>)}, Value = {value.Count}";
                case List<int> value when value.Count > 10: return $"Type Extra Large {nameof(List<int>)}, Value = {value.Count}";
                case null: return "Null Detected";
                default: return $"Type Unknown";
            }
        }
    }
}
