using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public interface IAndroid
    {
        void Call(string name);
        void Recieve();
        void SendMessage(string name);
        void RecieveMessage();
    }

    public class KitKat : IAndroid
    {
        public void Call(string name) => Console.WriteLine($"Calling {name} using KitKat");
        public void Recieve() => Console.WriteLine("Recieve using KitKat");
        public void RecieveMessage()=> Console.WriteLine("Recieve Message using KitKat");
        public void SendMessage(string name) => Console.WriteLine($"Send {name} Message using KitKat");
    }

    public class Lollipop : IAndroid
    {
        public void Call(string name) => Console.WriteLine($"Calling {name} using Lollipop");
        public void Recieve() => Console.WriteLine("Recieve using Lollipop");
        public void RecieveMessage() => Console.WriteLine("Recieve Message using Lollipop");
        public void SendMessage(string name) => Console.WriteLine($"Send {name} Message using Lollipop");
    }

    public class Nougat : IAndroid
    {
        public void Call(string name) => Console.WriteLine($"Calling {name} using Nougat");
        public void Recieve() => Console.WriteLine("Recieve using Nougat");
        public void RecieveMessage() => Console.WriteLine("Recieve Message using Nougat");
        public void SendMessage(string name) => Console.WriteLine($"Send {name} Message using Nougat");
    }
}
