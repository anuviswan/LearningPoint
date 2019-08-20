// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using LiskovSubstitution;
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
            Assert.Catch<ArgumentOutOfRangeException>(()=>school.GetStudentCount(age));
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
