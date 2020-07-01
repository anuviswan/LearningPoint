using SwitchExpressions.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwitchExpressions.Tests
{
    public class TypePatternTests
    {
        [Theory]
        [InlineData(1, "Type Int32, Value = 1")]
        [InlineData(1L, "Type Int64, Value = 1")]
        [InlineData("random string", "Type String, Value = random string")]
        public void ValuePatternEvaluate<T>(T direction, string expected)
        {
            var _evaluator = new TypePattern<T>();
            var result = _evaluator.Evaluate(direction);
            Assert.Equal(expected, result);
        }
    }
}
