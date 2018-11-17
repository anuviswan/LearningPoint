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
        private string _content = @"
wt      D       FV      FD
34.4   34.11    23.1    0.11
24.4   32.11    23    2.11
";
 
        [TestMethod]
        public void EnsureHeadersAreParsed()
        {
            var inputHeaders = new List<string>(new []{ "wt", "D", "FV", "FD" });
            var headers = TableParser.Headers.Parse(_content);
            Assert.AreEqual(4, headers.Count);
            CollectionAssert.AreEqual(inputHeaders, headers);
        }
    }
}
