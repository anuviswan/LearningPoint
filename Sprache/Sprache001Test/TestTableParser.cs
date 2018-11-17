using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sprache;
using Sprache001;

namespace Sprache001Test
{
    [TestClass]
    public class TestTableParser
    {
        private string _contentWithStringHeaders = @"
wt      D      FV      FD
34.4   34.11    23.1    0.11
24.4   32.11    23    2.11
";

        private string _contentWithAlphanumericHeaders = @"
wt      D2       F1V      FD
34.4   34.11    23.1    0.11
24.4   32.11    23    2.11
";


        [TestMethod]
        public void WhenStringWithWhiteSpace_ReturnString()
        {
            var inputString = " abc ";
            var result = TableParser.AlphaNumericParser.Parse(inputString);
            Assert.AreEqual("abc", result);
        }

        [TestMethod]
        public void WhenSingleCharacterWithWhiteSpaceIsParsed_ReturnChar()
        {
            var inputString = " a ";
            var result = TableParser.AlphaNumericParser.Parse(inputString);
            Assert.AreEqual("a", result);
        }

        [TestMethod]
        public void WhenAlphaNumericStringWithWhiteSpaceIsParsed_ReturnAlphaNumeric()
        {
            var inputString = " a1 ";
            var result = TableParser.AlphaNumericParser.Parse(inputString);
            Assert.AreEqual("a1", result);
        }

        [TestMethod]
        public void WhenStringOnlyHeadersSeparatedByWhiteSpaces_ReturnListOfHeaders()
        {
            var intputString = "wt      D      FV      FD";
            var inputHeaders = new List<string>(new []{ "wt", "D", "FV", "FD" });
            var headers = TableParser.HeaderListParser.Parse(intputString);

            Assert.AreEqual(4, headers.Count);
            CollectionAssert.AreEqual(inputHeaders, headers);
        }


        [TestMethod]
        public void WhenAlphanumericHeadersSeparatedByWhiteSpaces_ReturnListOfHeaders()
        {
            var intputString = "wt      D2      F1V      FD";
            var inputHeaders = new List<string>(new[] { "wt", "D2", "F1V", "FD" });
            var headers = TableParser.HeaderListParser.Parse(intputString);

            Assert.AreEqual(4, headers.Count);
            CollectionAssert.AreEqual(inputHeaders, headers);
        }


        [TestMethod]
        public void WhenIntegerIsParsed_ReturnInteger()
        {
            var input = " 3 ";
            var result = TableParser.DecimalValueParser.Parse(input);
            Assert.AreEqual(3d, result);
        }

        [TestMethod]
        public void WhenDecimalIsParsed_ReturnDecimal()
        {
            var input = " 3.2 ";
            var result = TableParser.DecimalValueParser.Parse(input);
            Assert.AreEqual(3.2d, result);
        }

        [TestMethod]
        public void WhenDecimalsDelimitedByUnknownWhiteSpaceIsParsed_ReturnListOfDecimals()
        {
            var input = "3.2  4.5 6 8.9";
            var result = TableParser.ValueList.Parse(input);
            Assert.AreEqual(result.Count, 4);
            CollectionAssert.AreEqual(new[] { 3.2, 4.5, 6, 8.9 }, result);
        }

        [TestMethod]
        public void WhenMultiLineDecimalsDelimitedByUnknownWhiteSpaceIsParsed_ReturnListOfDecimals()
        {
            var input = @"3.2  4.5 6 8.9
4.5 6 78.9 8";
            var result = TableParser.ValueList.Parse(input);
            Assert.AreEqual(result.Count, 8);
            CollectionAssert.AreEqual(new[] { 3.2, 4.5, 6, 8.9, 4.5,6,78.9,8}, result);
        }


    }
}
