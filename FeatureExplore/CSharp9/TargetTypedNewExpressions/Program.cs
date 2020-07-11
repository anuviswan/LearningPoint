using System;
using System.Collections.Generic;

namespace TargetTypedNewExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary = new()
            {
                ["Name1"] = "Anu Viswan",
                ["Name2"] = "Jia Anu"
            };
            Foo foo = new (){ FirstName = nameof(Foo.FirstName) };
            foo.Get(new() { UserName = nameof(Bar.UserName) });
        }
    }

    public class Foo
    {
        public string FirstName { get; set; }
        public string Get(Bar bar) => bar.UserName;  
    }

    public class Bar
    {
        public string UserName { get; set; }
    }
}
