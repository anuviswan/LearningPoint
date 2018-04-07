using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public class SmartPhone
    {
        protected IAndroid _android;
        public SmartPhone(IAndroid android) => _android = android;

        public virtual void Phone(string name) => _android.Call(name);
        public virtual void SendMessage(string name) => _android.SendMessage(name);
    }

    public class NewAgeSmartPhone : SmartPhone
    {
        public NewAgeSmartPhone(IAndroid android) : base(android) { }

        public override void Phone(string name)
        {
            Console.WriteLine("New Age Phone Call, Optimization started");
            base._android.Call(name);
        }
        public override void SendMessage(string name)
        {
            Console.WriteLine("New Age Message");
            _android.SendMessage(name);
        }
    }
}
