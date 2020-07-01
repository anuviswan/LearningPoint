using SwitchExpressions.Patterns;
using Xunit;

namespace SwitchExpressions.Tests
{
    public class ValuePatternTests
    {
        private IEvaluate<Direction> _evaluator;
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
            var result = _evaluator.Evaluate(direction);
            Assert.Equal(expected, result);
        }
    }
}
