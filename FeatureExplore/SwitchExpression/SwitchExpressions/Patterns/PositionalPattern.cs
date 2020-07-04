using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class PositionalPattern : ISwitchExpression<Person>, ISwitchStatement<Person>
    {
        public string EvaluateSwitchExpression(Person criteria) => criteria switch
        {
            ("Anu", _, 36 )=> "FirstName and Age Matched",
            (_,"Viswan",_) person when person.Age < 40 => "LastName With Age Less than Matched",
            (_,"Doe",_) => "LastName Matched",
            { } => "Not Found",
            null => "Input was null"
        };

        public string EvaluateSwitchStatement(Person criteria)
        {
            switch (criteria)
            {
                case ("Anu",_,36) :
                    return "FirstName and Age Matched";
                case (_,"Viswan",var age) when age < 40:
                    return "LastName With Age Less than Matched";
                case (_,"Doe",_):
                    return "LastName Matched";
                case { }:
                    return "Not Found";
                case null:
                    return "Input was null";
            };
        }
    }
}
