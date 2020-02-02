using Microsoft.VisualStudio.TestTools.UnitTesting;
using GateApp.CardDb;

namespace GateApp.CardDb
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckBalanceAfterCharge()
        {
            // Arrange
            double balance = 11.99;
            double amount = 4.55;
            double expected = 7.44;

            DTOCard card = new GateApp.CardDb.DTOCard("123412341234123412", "user1", balance, "");

            // Act
            card.Charge(amount);

            // Assert
            double actual = card.GetBalance();
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        
        [TestMethod]
        public void CheckBalanceAfterChargeWhenCardIsEmpty()
        {
            // Arrange
            double balance = 0.0;
            double amount = 4.55;
            double expected = 0.0;

            DTOCard card = new GateApp.CardDb.DTOCard("123412341234123412", "user1", balance, "");

            // Act
            card.Charge(amount);

            // Assert
            double actual = card.GetBalance();
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void CheckBalanceAfterChargeWhenCardHaveTooSmallBalance()
        {
            // Arrange
            double balance = 1.0;
            double amount = 1.5;
            double expected = 1.0;

            DTOCard card = new GateApp.CardDb.DTOCard("123412341234123412", "user1", balance, "");

            // Act
            card.Charge(amount);

            // Assert
            double actual = card.GetBalance();
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
