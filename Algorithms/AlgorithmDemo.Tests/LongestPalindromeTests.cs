using System;
using Xunit;

namespace AlgorithmDemo.Tests
{
    public class LongestPalindromeTests
    {
        [Theory]
        [InlineData("abaabg","baab")]
        [InlineData("fabag","aba")]
        [InlineData("a","a")]
        public void LongestPalindrome_ExpandWithCorners(string input,string expectedOutput)
        {
            var alg = new LongestPalindrome();
            var result = alg.ExpandingWithCorners(input);
            Assert.Equal(expectedOutput,result);
        }
    }
}
