using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoR
{
    class Program
    {
        static void Main(string[] args)
        {
            IWaterfall Handler1 = new Requirements();
            IWaterfall Handler2 = new Design();
            IWaterfall Handler3 = new Implementation();
            IWaterfall Handler4 = new Verification();
            IWaterfall Handler5 = new Deployment();
            IWaterfall Handler6 = new Maintenance();

            Handler1.NextStage = Handler2;
            Handler2.NextStage = Handler3;
            Handler3.NextStage = Handler4;
            Handler4.NextStage = Handler5;
            Handler5.NextStage = Handler6;

            Handler1.Execute();
            Console.ReadLine();
        }
    }
}
