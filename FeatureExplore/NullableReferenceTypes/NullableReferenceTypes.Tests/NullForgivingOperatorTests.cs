// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NullableReferenceTypes.Tests
{
    [TestFixture]
    public class NullForgivingOperatorTests
    {
        [Test]
        
        public void TestMethod()
        {
            var instance = new NullForgivingOperator(null);
            Assert.IsInstanceOf<NullForgivingOperator>(instance);
            Assert.IsNotNull(instance);
        }
    }
}
