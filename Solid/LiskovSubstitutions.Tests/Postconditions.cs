using NUnit.Framework;
using LiskovSubstitution.PostConditions;
using System.Collections;

namespace LiskovSubstitutions.Tests
{
    [TestFixture]
    public class Postconditions
    {
        [Test]
        [TestCaseSource(typeof(Postconditions), nameof(TestCases))]
        public void TestLabFeeForSchool(School school, long studentId)
        {
            Assert.Greater(school.CalculateLabFees(studentId),0);
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
