using SwitchExpressions.Patterns;
using System.Collections.Generic;
using Xunit;

namespace SwitchExpressions.Tests
{
    public class TuplePatternTests
    {
        private TuplePattern _evaluator;
        public TuplePatternTests()
        {
            _evaluator = new TuplePattern();
        }

        [Theory]
        [MemberData(nameof(TestDataSource))]
        public void TuplePatternEvaluate(string firstName,string lastName,int age, string expected)
        {
            var resultSwitchExpression = _evaluator.EvaluateSwitchExpression(firstName,lastName,age);
            var resultSwitchStatement = _evaluator.EvaluateSwitchExpression(firstName, lastName, age);
            Assert.Equal(expected, resultSwitchExpression);
            Assert.Equal(resultSwitchStatement, resultSwitchExpression);
        }


        public static IEnumerable<object[]> TestDataSource => new List<object[]>
        {
            new object[]{"Anu", "Viswan",36, "FirstName and Age Matched" },
            new object[]{"Manu", "Viswan",33, "LastName With Age Less than Matched" },
            new object[]{"John", "Doe", 55, "LastName Matched" },
            new object[] {"Tony", "Stark",40, "Not Found" },
            new object[] {null,null,default,"Input was null"}
        };
    }
}
