﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SwitchExpressions.Patterns
{
    public class PropertyPattern : ISwitchExpression<Person> ,ISwitchStatement<Person>
    {
        public string EvaluateSwitchExpression(Person criteria) => criteria switch
        {
            { FirstName: "Anu", Age: 36 } => "FirstName and Age Matched",
            { LastName: "Viswan" } person when person.Age < 40 => "LastName With Age Less than Matched",
            { LastName: "Doe" } => "LastName Matched",
            { } => "Not Found",
            null => "Input was null"
        };

        public string EvaluateSwitchStatement(Person criteria)
        {
            switch (criteria)
            {
                case { FirstName:"Anu", Age:36}:
                    return "FirstName and Age Matched";
                case { LastName: "Viswan" } person when person.Age < 40:
                    return "LastName With Age Less than Matched";
                case { LastName: "Doe" }:
                    return "LastName Matched";
                case { }:
                    return "Not Found";
                case null:
                    return "Input was null";
            };
        }
    }
}
