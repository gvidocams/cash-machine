using System;

namespace CashMachine.Exceptions
{
    public class InvalidBanknoteException : Exception
    {
        public InvalidBanknoteException(int note)
            : base($"This cash machine can't process this note: {note}") {}
    }
}