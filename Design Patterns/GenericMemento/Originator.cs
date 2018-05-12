using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMemento
{
    [ProtoContract]
    public class Originator 
    {
        [ProtoMember(1)]
        public string FName { get; set; }
        [ProtoMember(2)]
        public string LName { get; set; }

        public void RestoreState(Memento<Originator> memento)
        {
            var instance = memento.Value;
            FName = instance.FName;
            LName = instance.LName;
        }

        public Memento<Originator> Save()
        {
            return new Memento<Originator>(this);
            
        }

    }
}
