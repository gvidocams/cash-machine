using System;
using System.Collections.Generic;
using CashMachine.Exceptions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CashMachine.Tests
{
    [TestClass]
    public class CashMachineTests
    {
        private SortedDictionary<int, int> _banknotes;
        private ICashMachine _cashMachine;

        [TestInitialize]
        public void Setup()
        {
            _banknotes = new SortedDictionary<int, int>
            {
                {5, 0},
                {10, 0},
                {20, 0},
                {50, 0},
                {100, 0}
            };
            _cashMachine = new CashMachine(_banknotes);
        }
        
        [TestMethod]
        public void Insert_InsertsValidCash_NoErrors()
        {
            var notes = new[] { 5, 10, 20, 50, 100 };
            
            _cashMachine.Insert(notes);
            
            foreach (var note in _banknotes)
            {
                note.Value.Should().Be(1);
            }
        }

        [TestMethod]
        public void Insert_InsertsInvalidCash_ThrowsError()
        {
            var notes = new[] { 7 };

            Action act = () => _cashMachine.Insert(notes);

            act.Should().Throw<InvalidBanknoteException>()
                .WithMessage("This cash machine can't process this note: 7");
        }

        [TestMethod]
        public void Withdraw_Withdraws5Euro_ShouldChangeBanknotesAmount()
        {
            _banknotes[5] = 1;

            _cashMachine.Withdraw(5).Should().Be(5);

            _banknotes[5].Should().Be(0);
        }

        [TestMethod]
        public void Withdraw_Withdraws105Euro_ShouldChangeBanknotesAmount()
        {
            _banknotes[5] = 1;
            _banknotes[100] = 1;

            _cashMachine.Withdraw(105).Should().Be(105);

            _banknotes[5].Should().Be(0);
            _banknotes[100].Should().Be(0);
        }

        [TestMethod]
        public void Withdraw_Withdraws1065Euro_ShouldChangeBanknotesAmount()
        {
            _banknotes[5] = 1;
            _banknotes[10] = 1;
            _banknotes[50] = 1;
            _banknotes[100] = 10;

            _cashMachine.Withdraw(1065).Should().Be(1065);

            _banknotes[5].Should().Be(0);
            _banknotes[10].Should().Be(0);
            _banknotes[50].Should().Be(0);
            _banknotes[100].Should().Be(0);
        }
    }
}
