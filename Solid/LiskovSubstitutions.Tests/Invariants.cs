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
        public void TestInvariants(Type studentType,string name, int age)
        {
            var student = (Student)Activator.CreateInstance(studentType,name,age);
            Assert.AreEqual(age, student.Age);
        }

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(typeof(Student),"Jia", 3);
                yield return new TestCaseData(typeof(NurseryStudent), "Jia", 3);
            }
        }
    }
}
