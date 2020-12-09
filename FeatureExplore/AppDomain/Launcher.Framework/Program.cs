using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Launcher.Framework
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine($"Parent App domain : {Thread.GetDomain().FriendlyName}");
            Console.WriteLine("Creating child app domain....");
            var childDomain = AppDomain.CreateDomain("ChildDomain");
            Console.WriteLine($"Child App Domain : {childDomain.FriendlyName}");
            Console.WriteLine($"Launching application in child app domain..");
            childDomain.ExecuteAssemblyByName("MockApp");
            Console.ReadLine();
        }
    }
}
