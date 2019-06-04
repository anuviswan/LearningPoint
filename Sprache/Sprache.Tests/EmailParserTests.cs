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
        [TestCase("This is a text without email",ExpectedResult =0)]
        [TestCase("This text has one email id ( anu.viswan@gmail.com )",ExpectedResult =1)]
        public int Parse(string inputString)
        {
            var parser = new EmailParser();
            var result = parser.Parser(inputString);
            return result.Count();
        }


    }
}
