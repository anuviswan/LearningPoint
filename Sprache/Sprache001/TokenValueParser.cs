using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprache001
{
    public static class TokenValueParser
    {
        public static readonly Parser<string> Identifier = Parse.Letter.AtLeastOnce().Text().Token();

        public static readonly Parser<string> Value = (from open in Parse.Char('\'')
                                                       from content in Parse.CharExcept('\'').Many().Text()
                                                       from close in Parse.Char('\'')
                                                       select content).Token();

        public static readonly Parser<KeyValuePair<string,string>> Question = from id in Identifier from prompt in Value select new KeyValuePair<string,string>(id,prompt);
    }

}
