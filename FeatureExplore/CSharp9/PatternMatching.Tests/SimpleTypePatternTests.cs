using PatternMatching.Patterns;
using System;
using Xunit;

namespace PatternMatching.Tests
{
    public class TypePatternTests
    {
        [Theory]
        [InlineData(1, "Type Int32, Value = 1")]
        [InlineData(1L, "Type Int64, Value = 1")]
        [InlineData("random string", "Type String, Value = random string")]
        [InlineData(7F, "Type Unknown")]
        [InlineData(null, "Null Detected")]
        public void TypePatternEvaluate<T>(T direction, string expected)
        {
            var _evaluator = new SimpleTypePattern<T>();
            var resultSwitchExpression = _evaluator.EvaluateSwitchExpression(direction);
            var resultSwitchStatement = _evaluator.EvaluateSwitchExpression(direction);
            Assert.Equal(expected, resultSwitchExpression);
            Assert.Equal(resultSwitchStatement, resultSwitchExpression);
        }
    }
}
