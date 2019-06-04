// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sprache.Tests
{
    [TestFixture]
    public class EmailParserTests
    {
        [Test]
        public IEnumerable<string> Parse(string inputString)
        {
            var parser = new EmailParser();
            var result = parser.Parser(inputString);
            return result;
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("this is a  test without email").Returns(Enumerable.Empty<string>());
            }
        }

    }
}
