// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using LiskovSubstitution.PreConditions;
using NUnit.Framework;

namespace LiskovSubstitutions.Tests
{
    [TestFixture]
    public class Preconditions
    {
        [Test]
        [TestCaseSource(typeof(Preconditions), nameof(TestCases))]
        public void GetStudentCount(School school,int age)
        {
            Assert.GreaterOrEqual(school.GetStudentCount(age), 0);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new School(), 7);
                yield return new TestCaseData(new Kindergarden(), 7);
            }
        }
    }
}
