using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public interface IAtmState
    {
        void DoOperation();
    }

    public class ATMWithState
    {
        public IAtmState CurrentState { get; set; }

        public void DoOperation()
        {
            CurrentState.DoOperation();
        }
    }

    public class CardNotInsertedState : IAtmState
    {
        public void DoOperation()
        {
            Console.WriteLine("Current: Card Not Inserted, Next: Insert Your Card");
        }
    }

    public class NotValidatedState : IAtmState
    {
        public void DoOperation()
        {
            Console.WriteLine("Current: Not Valided, Next: Validate your card by entering PIN");
        }
    }

    public class ValidatedState : IAtmState
    {
        public void DoOperation()
        {
            Console.WriteLine("Current: Validated, Next: Please enter amount to withdraw");
        }
    }
}
