using SwitchExpressions.Patterns;
using Xunit;

namespace SwitchExpressions.Tests
{
    public class ValuePatternTests
    {
        private ISwitchExpression<Direction> _evaluator;
        public ValuePatternTests()
        {
            _evaluator = new ValuePattern();
        }
        [Theory]
        [InlineData(Direction.Right,"Direction : Right")]
        [InlineData(Direction.Left,"Direction : Left")]
        [InlineData(Direction.Up,"Direction : Up")]
        [InlineData(Direction.Down,"Direction : Down")]
        public void ValuePatternEvaluate(Direction direction,string expected)
        {
            var resultSwitchExpression = _evaluator.EvaluateSwitchExpression(direction);
            var resultSwitchStatement = _evaluator.EvaluateSwitchExpression(direction);
            Assert.Equal(expected, resultSwitchExpression);
            Assert.Equal(resultSwitchStatement, resultSwitchExpression);
        }
    }
}
