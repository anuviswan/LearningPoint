using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprache001
{
    class Program
    {
        static void Main(string[] args)
        {
            var parsed = TokenValueParser.Question.Parse("Hello 'test'");
            Console.WriteLine($"Key= {parsed.Key}, Value={parsed.Value}");
            Console.ReadLine();

        }

       
    }
}
