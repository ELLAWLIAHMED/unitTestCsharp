using Accounts_Core.Shared;
using Models;
using System;

namespace BankAccount.Services

{
    public class AccountService
    {
        public bool TransferMoney(Account SourceAccount, Account DestinationAccount, double Amount)
        {
            // TODO : Inputs Verification

            if (SourceAccount == null || DestinationAccount == null)
                throw new ArgumentNullException(ExceptionMessages.NULL_ACCOUNT_EXCEPTION_MESSAGE);
            
            if (Amount <= 0)
                throw new ArgumentException(ExceptionMessages.INVALID_AMOUNT_EXCEPTION_MESSAGE);

            if (SourceAccount.Balance < Amount)
                throw new InvalidOperationException(ExceptionMessages.BALANCE_NOT_ENOUGH_EXCEPTION_MESSAGE);

            // TODO : Money Transfer

            SourceAccount.MoneyWithdrawal(Amount);
            DestinationAccount.ReceiveMoney(Amount);


            return true;
        }

        public double CalculateMonthlyPayment(double amount, double rate, int duration)
        {
            if(amount <= 0 || duration <=0 || rate <0)
                throw new ArgumentException(ExceptionMessages.INVALID_INPUTS_EXCEPTION_MESSAGE);

            rate /= 1200;
            double t1 = amount * rate;
            double t2 = Math.Pow(1 + rate, -duration);
            
            return t1 / (1 - t2);
        }


    }

}
