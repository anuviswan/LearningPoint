using LiskovSubstitution.Invariants;
using NUnit.Framework;
using System;
using System.Collections;

namespace LiskovSubstitutions.Tests
{
    [TestFixture]
    public class Invariants
    {
        [Test]
        [TestCaseSource(typeof(Invariants), nameof(TestCases))]
        public void TestInvariants(Student student,string name)
        {
            student.AssignName(name);
            Assert.Greater(student.Name.Length, 0);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(new Student(), null);
                yield return new TestCaseData(new NurseryStudent(),null);
            }
        }
    }
}
