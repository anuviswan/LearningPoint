using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class TypePattern<T> : IEvaluate<T>
    {
        public string Evaluate(T criteria) => criteria switch
        {
            Int32 value => $"Type {nameof(Int32)}, Value = {value}",
            Int64 value => $"Type {nameof(Int64)}, Value = {value}",
            string value => $"Type {nameof(String)}, Value = {value}",
            IEnumerable<int> value => $"Type {nameof(IEnumerable<int>)}, Value = {value}",
        };
    }
}
