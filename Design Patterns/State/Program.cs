using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Approach without State Pattern

            var atmWithoutState = new ATMWithoutState();
            atmWithoutState.CurrentState = eState.CardNotInserted;
            atmWithoutState.DoOperation();
            atmWithoutState.CurrentState = eState.NotValidated;
            atmWithoutState.DoOperation();
            atmWithoutState.CurrentState = eState.Validated;
            atmWithoutState.DoOperation();
            #endregion


            #region Approach with State Pattern
            var atmWithState = new ATMWithState();
            atmWithState.CurrentState = new CardNotInsertedState();
            atmWithState.DoOperation();
            atmWithState.CurrentState = new NotValidatedState();
            atmWithState.DoOperation();
            atmWithState.CurrentState = new ValidatedState();
            atmWithState.DoOperation();
            #endregion
            Console.ReadLine();
        }
    }
}
