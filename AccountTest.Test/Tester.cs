namespace AccountTest.Test
{
    [TestFixture]
    public class Tester
    {
        private double epsilon = 1e-6;

        [Test]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            Account account = new Account(-20);

            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }

        [Test]
        public void DepositWithDrawNotAcceptNegativeNumbers()
        {
            Account account = new Account(20);

            Assert.AreEqual(false, account.Deposit(-20));
            Assert.AreEqual(false, account.Withdraw(-20));
        }

        [Test]
        public void CheckOverDraftLimit()
        {
            Account account = new Account(30);
            
            Assert.AreEqual(false, account.Withdraw(40));
        }

        [Test]
        public void DepositWithDrawReturnCorrectResult()
        {
            Account account = new Account(30);
            account.Deposit(20);
            account.Withdraw(10);

            Assert.AreEqual(10, account.Balance, epsilon);
        }

        [Test]
        public void DepositWithDrawWorksCorrect()
        {
            Account account = new Account(30);
            Assert.AreEqual(true, account.Deposit(20));
            Assert.AreEqual(true, account.Withdraw(10));

        }
    }
}