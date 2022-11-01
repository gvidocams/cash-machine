using CashMachine.Exceptions;
using CashMachine.Services;
using System.Collections.Generic;

namespace CashMachine
{
    public class CashMachine : ICashMachine
    {
        private int[] _validNotes = new[] { 100, 50, 20, 10, 5 };
        private SortedDictionary<int, int> _banknotes = new SortedDictionary<int, int>();

        public CashMachine()
        {
            _banknotes = CashMachineService.SetBanknotesKeys();
        }

        public CashMachine(SortedDictionary<int, int> banknotes)
        {
            _banknotes = banknotes;
        }

        public int Withdraw(int amount)
        {
            var cash = 0;

            foreach (var note in _validNotes)
            {
                while (amount >= note && _banknotes[note] > 0)
                {
                    if (cash + note <= amount)
                    {
                        cash += note;
                        _banknotes[note]--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (cash == amount)
                {
                    return cash;
                }
            }

            return cash;
        }

        public void Insert(int[] cash)
        {
            foreach (int note in cash)
            {
                if (!_banknotes.ContainsKey(note))
                {
                    throw new InvalidBanknoteException(note);
                }

                _banknotes[note]++;
            }
        }
    }
}