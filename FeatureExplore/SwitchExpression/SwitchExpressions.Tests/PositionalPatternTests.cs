using SwitchExpressions.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SwitchExpressions.Tests
{
    public class PositionalPatternTests
    {
        private ISwitchExpression<Person> _evaluator;
        public PositionalPatternTests()
        {
            _evaluator = new PositionalPattern();
        }

        [Theory]
        [MemberData(nameof(TestDataSource))]
        public void PropertyPatternEvaluate(Person person, string expected)
        {
            var resultSwitchExpression = _evaluator.EvaluateSwitchExpression(person);
            var resultSwitchStatement = _evaluator.EvaluateSwitchExpression(person);
            Assert.Equal(expected, resultSwitchExpression);
            Assert.Equal(resultSwitchStatement, resultSwitchExpression);
        }


        public static IEnumerable<object[]> TestDataSource => new List<object[]>
        {
            new object[]{new Person{FirstName="Anu", LastName="Viswan",Age=36}, "FirstName and Age Matched" },
            new object[]{new Person { FirstName = "Manu", LastName = "Viswan", Age = 33 }, "LastName With Age Less than Matched" },
            new object[]{new Person { FirstName = "John", LastName = "Doe", Age = 55 }, "LastName Matched" },
            new object[] {new Person { FirstName = "Tony", LastName="Stark", Age = 40} , "Not Found" },
            new object[] {null,"Input was null"}
        };
    }
}
