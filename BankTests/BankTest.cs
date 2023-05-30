using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTests
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debitedcorrectly");
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(200)]
        public void Debit_WithInvalidValues(int amount)
        {
            BankAccount account = new BankAccount("Mr. Bryan Walton", 100);
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Debit(amount));
            var expectedMessage = "Specified argument was out of the range of valid values. (Parameter 'amount')";
            Assert.AreEqual(expectedMessage, ex.Message);

        }

    }
}