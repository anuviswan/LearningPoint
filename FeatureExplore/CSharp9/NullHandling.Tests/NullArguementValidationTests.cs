using System;
using Xunit;

namespace NullHandling.Tests
{
    public class NullArguementValidationTests
    {
        [Theory]
        [InlineData(null)]
        public void DemoUsingExplicitValidation(Foo instance)
        {
            var nullArguementValidation = new NullArgumentValidation();
            Assert.Throws<ArgumentNullException>(()=>nullArguementValidation.DemoUsingExplicitValidation(instance));
        }

    }
}
