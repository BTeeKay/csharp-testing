using BankAccountNS;

namespace BankTests

{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void DebitWithValidAmountUpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Brian Kerr", beginningBalance);

            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void DebitWhenAmountIsLessThatZeroShouldThroughOutOfRange()
        {
            double beginningBalance = 11.99;
            double debiamount = -13.00;
            BankAccount account = new BankAccount("Bob", beginningBalance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debiamount));
        }

        [TestMethod]
        public void DebitWhenAmountIsMoreThanAmountShouldThroughOutOfRange()
        {
            double beginningBalance = 11.99;
            double debiamount = 13.00;
            BankAccount account = new BankAccount("Bob", beginningBalance);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debiamount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

    }
}