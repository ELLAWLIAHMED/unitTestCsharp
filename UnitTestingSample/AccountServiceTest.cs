using Accounts_Core;
using Accounts_Core.Shared;
using BankAccount;
using BankAccount.Services;
using Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingSample
{
    [TestFixture]
    public class AccountServiceTest
    {
        private static readonly double ZERO_BALANCE = 0;
        
        private static readonly double Random_BALANCE = 100;


        private AccountService accountService;


        
        [OneTimeSetUp]
        public void InitializeClass()
        {
            accountService  = new AccountService();
        }

        [SetUp]
        public void Initialize()
        {
            Console.WriteLine("initializing ...");
        }


        [Test]
        [Category("Credit Simulation")]
        [TestCaseSource(typeof(CreditSimulationTestData), nameof(CreditSimulationTestData.ValidCreditSimulationData))]
        public void ShouldCalculateMonthlyPaiement(double rate, int duration, double amount, double ExpectedValue)
        {
            /*//Given
            double rate = 7.5;
            int duration = 36;
            double amount = 100000;
            double ExpectedValue = 3110.62;*/


            //When
            double CalculatedValue = accountService.CalculateMonthlyPayment(amount, rate, duration);

            //Then
            Assert.That(Math.Abs(CalculatedValue - ExpectedValue), Is.LessThan(0.01));
        }

        [Test]
        [Category("Credit Simulation")]
        [TestCaseSource(typeof(CreditSimulationTestData), nameof(CreditSimulationTestData.InValidCreditSimulationData))]
        public void ShouldThrowAnExceptionWhenInputIsInvalid(double rate, int duration, double amount)
        {
            //Given
            /* double rate = 10000;
             int duration = -1;
             double amount = 100000;*/



            //When
            //double CalculatedValue = accountService.CalculateMonthlyPayment(amount, rate, duration);

            //Then
            Assert.That(
                () => accountService.CalculateMonthlyPayment(amount, rate, duration),
                Throws.TypeOf<ArgumentException>()
                .With
                .Property("Message")
                .Contains(ExceptionMessages.INVALID_INPUTS_EXCEPTION_MESSAGE)

                );
        }


        [Test]
        //[Ignore("reason")]
        [Category("Money Transactions")]
        public void ShouldTransferMoney()
        {
            // Given (Arrange)
            var SourceAccount = new Account(AccountServiceTest.Random_BALANCE, Utils.GenerateRandomRib(9));
            var DestinationAccount = new Account(AccountServiceTest.ZERO_BALANCE, Utils.GenerateRandomRib(9));

            // WHEN (Act)

            var IsPassed = accountService.TransferMoney(SourceAccount, DestinationAccount, Random_BALANCE);

            // THEN (Assert)
            
            // classic model
            Assert.AreEqual(SourceAccount.Balance, ZERO_BALANCE);
            Assert.AreEqual(DestinationAccount.Balance, Random_BALANCE);
            Assert.IsTrue(IsPassed);
           
            // Constraint based model (recommandé)
            Assert.That(IsPassed, Is.True);
            Assert.That(SourceAccount.Balance, Is.EqualTo(ZERO_BALANCE));
            Assert.That(DestinationAccount.Balance, Is.EqualTo(Random_BALANCE));
        }

        [Test]
        [Category("Exception Handling")]
        public void ShouldThrowAnExceptionWhenTheAmountIsInvalid()
        {
            // Given (Arrange)
            var SourceAccount = new Account(AccountServiceTest.Random_BALANCE, Utils.GenerateRandomRib(9));
            var DestinationAccount = new Account(AccountServiceTest.ZERO_BALANCE, Utils.GenerateRandomRib(9));

            // WHEN (Act)

            //bool IsPassed = accountService.TransferMoney(SourceAccount, DestinationAccount, ZERO_BALANCE);

            // THEN (Assert)

            Assert.That(
                () => accountService.TransferMoney(SourceAccount, DestinationAccount, ZERO_BALANCE)
                , Throws.TypeOf<ArgumentException>()
                .With
                .Property("Message")
                .Contains(ExceptionMessages.INVALID_AMOUNT_EXCEPTION_MESSAGE)
                );
        }

        [Test]
        [Category("Exception Handling")]
        public void ShouldThrowAnExceptionWhenAccounIsNull()
        {
            // Given (Arrange)
            var SourceAccount = new Account(AccountServiceTest.Random_BALANCE, Utils.GenerateRandomRib(9));
            Account DestinationAccount = null;

            // WHEN (Act)

            //bool IsPassed = accountService.TransferMoney(SourceAccount, DestinationAccount, ZERO_BALANCE);

            // THEN (Assert)

            Assert.That(
                () => accountService.TransferMoney(SourceAccount, DestinationAccount, Random_BALANCE)
                , Throws.TypeOf<ArgumentNullException>()
                .With
                .Property("Message")
                .Contains(ExceptionMessages.NULL_ACCOUNT_EXCEPTION_MESSAGE)
                );
        }

        [Test]
        [Category("Exception Handling")]
        public void ShouldThrowAnExceptionWhenBalanceIsNotEnough()
        {
            // Given (Arrange)
            var SourceAccount = new Account(AccountServiceTest.ZERO_BALANCE, Utils.GenerateRandomRib(9));
            var DestinationAccount = new Account(AccountServiceTest.ZERO_BALANCE, Utils.GenerateRandomRib(9));

            // WHEN (Act)

            //bool IsPassed = accountService.TransferMoney(SourceAccount, DestinationAccount, ZERO_BALANCE);

            // THEN (Assert)

            Assert.That(
                () => accountService.TransferMoney(SourceAccount, DestinationAccount, Random_BALANCE)
                , Throws.TypeOf<InvalidOperationException>()
                .With
                .Property("Message")
                .Contains(ExceptionMessages.BALANCE_NOT_ENOUGH_EXCEPTION_MESSAGE)
                );
        }


        

    } 
}
