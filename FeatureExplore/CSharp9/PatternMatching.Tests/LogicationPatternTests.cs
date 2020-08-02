using PatternMatching.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PatternMatching.Tests
{
    public class LogicationPatternTests
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TypePatternEvaluate<T>(T direction, string expected)
        {
            var _evaluator = new LogicalPattern<T>();
            var resultSwitchExpression = _evaluator.EvaluateSwitchExpression(direction);
            var resultSwitchStatement = _evaluator.EvaluateSwitchExpression(direction);
            Assert.Equal(expected, resultSwitchExpression);
            Assert.Equal(resultSwitchStatement, resultSwitchExpression);
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[]{1, "Type Int32, Value = 1"},
            new object[]{1L, "Type Int64, Value = 1"},
            new object[]{"random string", "Type String, Value = random string"},
            new object[]{7F, "Type Unknown"},
            new object[]{null, "Null Detected"},
            new object[]{ Enumerable.Range(1,3).ToList(), $"Type Small {nameof(List<int>)}, Value = {3}" },
            new object[]{ Enumerable.Range(1, 5).ToList(), $"Type Medium {nameof(List<int>)}, Value = {5}" },
            new object[]{ Enumerable.Range(1, 7).ToList(), $"Type Big {nameof(List<int>)}, Value = {7}" },
            new object[]{ Enumerable.Range(1, 15).ToList(), $"Type Extra Large {nameof(List<int>)}, Value = {15}" },
        };
    }
}
