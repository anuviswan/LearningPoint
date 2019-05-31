using System;
using NUnit.Framework;
using Singleton;

namespace DesignPattern.Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void TestMethod()
        {
            var instanceA = MySingleton.GetInstance();
            var instanceB = MySingleton.GetInstance();
            var random = new Random();


            Assert.AreSame(instanceA, instanceB);

            instanceA.Value = random.Next(1, 100);
            Assert.AreEqual(instanceA.Value, instanceB.Value);

            instanceA.Value = random.Next(1, 100);
            Assert.AreEqual(instanceA.Value, instanceB.Value);
        }
    }
}
