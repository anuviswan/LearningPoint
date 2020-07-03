using SwitchExpressions.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace SwitchExpressions.Tests
{
    public class PropertyPatternTests
    {
        private ISwitchExpression<Person> _evaluator;
        public PropertyPatternTests()
        {
            _evaluator = new PropertyPattern();
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
            new object[]{ new Person { FirstName = "John", LastName = "Doe", Age = 55 }, "LastName Matched" }
        };
    }
}
