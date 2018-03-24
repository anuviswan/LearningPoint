using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public enum eState
    {
        CardNotInserted,
        NotValidated,
        Validated
    }
    public class ATMWithoutState
    {
        public eState CurrentState { get; set; }

        
        public void DoOperation()
        {
            switch (CurrentState)
            {
                case eState.CardNotInserted:
                    Console.WriteLine("Current: Card Not Inserted, Next: Insert Your Card");
                    break;
                case eState.NotValidated:
                    Console.WriteLine("Current: Not Valided, Next: Validate your card by entering PIN");
                    break;
                case eState.Validated:
                    Console.WriteLine("Current: Validated, Next: Please enter amount to withdraw");
                    break;
            }
        }
    }
}
