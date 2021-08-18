using Bank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Bank.Test
{
    public class ATMTests
    {
        /// <summary>
        /// In this test we try to login with the wrong password
        /// and expect to get denied
        /// </summary>
        [Theory]
        [InlineData(8888)]
        [InlineData(6589)]
        [InlineData(2889)]
        public void Access_LoginUnsuccessfully(int Pincode)
        {
            ATM SampleATM = new ATM();

            Account UserAccount = new Account();
            UserAccount.AccountCard = new Card(Pincode);

            // Arrange (Expected)
            bool expected = false;

            // Act (Actual)
            bool actual = SampleATM.Access(UserAccount, 1234);

            // Assert	
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// In this test we try to login with the right password
        /// and expect to get access
        /// </summary>
        [Fact]
        public void Access_LoginSuccessfully()
        {
            ATM SampleATM = new ATM();

            Account UserAccount = new Account();
            UserAccount.AccountCard = new Card(1234);

            // Arrange (Expected)
            bool expected = true;

            // Act (Actual)
            bool actual = SampleATM.Access(UserAccount, 1234);

            // Assert	
            Assert.Equal(expected, actual);
        }




        /// <summary>
        /// In this test we try to login with the wrong password
        /// and expect to get denied
        /// </summary>
        [Fact]
        public void Access_LoginUnsuccessfullaaaasasdasdy()
        {
            ATM SampleATM = new ATM();

            Account UserAccount = new Account();
            UserAccount.AccountCard = new Card(new int());

            // Arrange (Expected)
            bool expected = false;

            // Act (Actual)
            bool actual = SampleATM.Access(UserAccount, 1234);

            // Assert	
            Assert.Equal(expected, actual);
        }



        /// <summary>
        /// In this test we try to withdraw money without having set a valid account
        /// and expect to not get access.
        /// </summary>
        [Fact]
        public void WithdrawMoney_AccessDenied()
        {
            ATM SampleATM = new ATM();

            // Arrange (Expected)
            string expected = null;

            // Act (Actual)
            string actual = SampleATM.WithdrawMoney(500);

            // Assert	
            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// In this test we try to withdraw money 
        /// and expect to do it without any issues
        /// </summary>
        [Theory]
        [InlineData(300)]
        [InlineData(int.MinValue)]
        [InlineData(-5)]
        public void AccountHasEnoughMoney_HasEnoughMoney(int Amount)
        {
            ATM SampleATM = new ATM();
            Account UserAccount = new Account();
            UserAccount.AccountCard = new Card(1234);
            UserAccount.Balance = 500;
            SampleATM.Access(UserAccount, 1234);

            // Arrange (Expected)
            bool expected = true;

            // Act (Actual)
            bool actual = SampleATM.AccountHasEnoughMoney(Amount);

            // Assert	
            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// In this test we try to withdraw money with a too low balance
        /// and expect to get an error
        /// </summary>
        [Theory]
        [InlineData(1000)]
        [InlineData(int.MaxValue)]
        public void AccountHasEnoughMoney_DoesNotHasEnoughMoney(int Amount)
        {
            ATM SampleATM = new ATM();
            Account UserAccount = new Account();
            UserAccount.AccountCard = new Card(1234);
            UserAccount.Balance = 500;
            SampleATM.Access(UserAccount, 1234);

            // Arrange (Expected)
            bool expected = false;

            // Act (Actual)
            bool actual = SampleATM.AccountHasEnoughMoney(Amount);

            // Assert	
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// In this test we try to withdraw money 
        /// and expect to do it without any issues
        /// </summary>
        [Fact]
        public void WithdrawMoney_AccessConfirmed()
        {
            ATM SampleATM = new ATM();
            Account UserAccount = new Account();
            UserAccount.Balance = 10000;
            UserAccount.AccountCard = new Card(1234);
            SampleATM.Access(UserAccount, 1234);

            // Arrange (Expected)
            string expected = "Success";

            // Act (Actual)
            string actual = SampleATM.WithdrawMoney(500);

            // Assert	
            Assert.Equal(expected, actual);
        }
    }
}
