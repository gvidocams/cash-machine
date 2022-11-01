using System;
using System.Collections.Generic;

namespace CashMachine
{
    public class Program
    {
        static void Main()
        {
            var notes = new SortedDictionary<int, int>()
            {
                {5, 0},
                {10, 0},
                {20, 0},
                {50, 0},
                {100, 0}
            };
            var cashMachine = new CashMachine(notes);
            cashMachine.Insert(new [] {5});

            Console.WriteLine(notes[5]);
        }
    }
}