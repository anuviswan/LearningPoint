using SwitchExpressions.Patterns;
using System;

namespace SwitchExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstration of Switch Expression");
            Console.WriteLine($"Evaluating Value Pattern : {new ValuePattern().EvaluateExpression(Direction.Right)}");
            Console.WriteLine($"Evaluating Type Pattern : {new TypePattern<string>().EvaluateExpression("Dummy Data")}");
            Console.ReadLine();
        }
    }
}
