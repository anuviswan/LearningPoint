using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseAlgorithm algo1 = new AlgorithmA();
            algo1.Execute();

            BaseAlgorithm algo2 = new AlgorithmB();
            algo2.Execute();

            BaseAlgorithm algo3 = new AlgorithmC();
            algo3.Execute();

            Console.ReadLine();
        }
    }
}
