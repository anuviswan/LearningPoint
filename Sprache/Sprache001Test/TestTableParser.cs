using System;
using System.Collections.Generic;
using System.Linq;
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


        #region String Parser
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
        #endregion

        #region Header List Parser
        [TestMethod]
        public void WhenStringOnlyHeadersSeparatedByWhiteSpaces_ReturnListOfHeaders()
        {
            var intputString = "wt      D      FV      FD";
            var inputHeaders = new List<string>(new[] { "wt", "D", "FV", "FD" });
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
        #endregion
        
        #region Decimal Parser
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
        #endregion

        #region Decimal List Parser
        [TestMethod]
        public void WhenDecimalsDelimitedByUnknownWhiteSpaceIsParsed_ReturnListOfDecimals()
        {
            var input = "3.2  4.5 6 8.9";
            var result = TableParser.LineOfValueList.Parse(input).ToList();
            Assert.AreEqual(4, result.Count());
            CollectionAssert.AreEqual(new[] { 3.2, 4.5, 6, 8.9 }, result.ToArray());
        }

        [TestMethod]
        public void WhenMultiLineDecimalsDelimitedByUnknownWhiteSpaceIsParsed_ReturnListOfDecimals()
        {
            var input = @"3.2  4.5 6 8.9
4.5 6 78.9 8";
            var result = TableParser.LineOfValueList.Parse(input).ToList();
            Assert.AreEqual(8, result.Count);
            CollectionAssert.AreEqual(new[] { 3.2, 4.5, 6, 8.9, 4.5, 6, 78.9, 8 }, result.ToArray());
        }
        #endregion

        #region Parse Table With Header and Values 
        [TestMethod]
        public void WhenTableWithHeadersAndDecimalValueIsParsed_ReturnTableStructure()
        {
            var mockedResult = new List<Dictionary<string, double>>();
            mockedResult.Add(new Dictionary<string, double>
            {
                ["wt"] = 34.4,
                ["D2"] = 34.11,
                ["F1V"] = 23.1,
                ["FD"] = 0.11,
            });
            mockedResult.Add(new Dictionary<string, double>
            {
                ["wt"] = 24.4,
                ["D2"] = 32.11,
                ["F1V"] = 23,
                ["FD"] = 2.11,
            });

            var result = TableParser.Table.Parse(_contentWithAlphanumericHeaders);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.ValueList.Count, 2);
            Assert.AreEqual(4, result.Headers.Count);
        }
        #endregion

    }

}
