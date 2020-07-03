using SwitchExpressions.Patterns;
using System;

namespace SwitchExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstration of Switch Expression");
            Console.WriteLine($"Evaluating Value Pattern : {new ValuePattern().EvaluateSwitchExpression(Direction.Right)}");
            Console.WriteLine($"Evaluating Type Pattern : {new TypePattern<string>().EvaluateSwitchExpression("Dummy Data")}");
            Console.ReadLine();
        }
    }
}
