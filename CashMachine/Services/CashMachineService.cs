using System.Collections.Generic;

namespace CashMachine.Services
{
    public static class CashMachineService
    {
        public static SortedDictionary<int, int> SetBanknotesKeys()
        {
            var notes = new SortedDictionary<int, int>();

            notes.Add(5, 0);
            notes.Add(10, 0);
            notes.Add(20, 0);
            notes.Add(50, 0);
            notes.Add(100, 0);

            return notes;
        }
    }
}