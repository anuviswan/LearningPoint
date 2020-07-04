using System.Collections;

namespace SwitchExpressions.Patterns
{
    public class TuplePattern 
    {
        public string EvaluateSwitchExpression(string firstName, string lastName, int age) => (firstName, lastName, age) switch
        {
            ("Anu", "Viswan", _) => "FirstName and Age Matched",
            (_, "Viswan", var a) when a < 40 => "LastName With Age Less than Matched",
            (_, "Doe", _) => "LastName Matched",
            (null, null, _) => "Input was null",
            (_, _, _) => "Not Found",
        };

        public string EvaluateSwitchStatement(string firstName, string lastName, int age)
        {
            switch ((firstName, lastName, age))
            {
                case ("Anu", "Viswan", _): return "FirstName and Age Matched";
                case (_, "Viswan", var a) when a < 40:  return "LastName With Age Less than Matched";
                case (_, "Doe", _): return "LastName Matched";
                case (null, null, _): return "Input was null";
                case (_, _, _): return "Not Found";
            };
        }
    }
}
