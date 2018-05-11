using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDP
{
    class Program
    {
        static void Main(string[] args)
        {
            IOriginator instance = new Originator();
            instance.FName = "Jia";
            instance.LName = "Anu";

            Caretaker<IOriginator> memoryCollection = new Caretaker<IOriginator>();
            memoryCollection.Add(instance.Save());

            instance.FName = "Sreena";
            instance.LName = "Anu";
            memoryCollection.Add(instance.Save());

            instance.FName = "Anu";
            instance.LName = "Viswan";

            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
            instance.RestoreState(memoryCollection.Instances().First());
            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
            instance.RestoreState(memoryCollection.Instances().Last());
            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
        }
    }
}
