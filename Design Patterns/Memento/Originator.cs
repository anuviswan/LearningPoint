using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDP
{
    public interface IOriginator
    {
        string FName { get; set; }
        string LName { get; set; }
        void RestoreState(Memento memento);
        Memento Save();
    }

    
    public class Originator: IOriginator
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public void RestoreState(Memento memento)
        {
            this.FName = memento.FName;
            this.LName = memento.LName;
        }

        public Memento Save()
        {
            return new Memento() {
                LName = this.LName,
                FName = this.FName                
            };
        }

    }
}
