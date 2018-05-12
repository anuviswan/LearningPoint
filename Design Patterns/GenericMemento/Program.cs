using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMemento
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator instance = new Originator();
            instance.FName = "Jia";
            instance.LName = "Anu";

            Caretaker<Originator> memoryCollection = new Caretaker<Originator>();
            memoryCollection.Add(instance.Save());

            instance.FName = "Sreena";
            instance.LName = "Anu";
            memoryCollection.Add(instance.Save());

            instance.FName = "Anu";
            instance.LName = "Viswan";

            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
            instance.RestoreState(memoryCollection.GetLastKnownState(1));
            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
            instance.RestoreState(memoryCollection.GetLastKnownState(2));
            Console.WriteLine($"FName = {instance.FName}, LName = {instance.LName}");
        }
    }
}
