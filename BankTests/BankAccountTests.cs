using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Mr. Roman Abramovich", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;

            Assert.AreEqual(expected, actual, 0.001, "Списание прошло неверно");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowException()
        {
            BankAccount account = new BankAccount("Test", 10);

            account.Debit(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowException()
        {
            BankAccount account = new BankAccount("Test", 10);

            account.Debit(20);
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            double expected = 16.99;

            BankAccount account = new BankAccount("Test", beginningBalance);

            account.Credit(creditAmount);

            double actual = account.Balance;

            Assert.AreEqual(expected, actual, 0.001, "Пополнение прошло неверно");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowException()
        {
            BankAccount account = new BankAccount("Test", 10);

            account.Credit(-5);
        }
    }
}