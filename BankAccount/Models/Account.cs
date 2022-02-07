using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Account
    {
        public long Id { get; set; }
        
        public DateTime CreationDate { get; set; }

        public double Balance { get; set; }

        public bool IsLocked { get; set; }

        public long Rib { get; set; }

        public Account() { }

        public Account(double balance, long rib)
        {
            CreationDate = DateTime.Now;
            Balance = balance;
            IsLocked = false;
            Rib = rib;
        }

        public bool MoneyWithdrawal(double amount)
        {
            if (amount < 0) return false;
            if ( Balance < amount) return false;

            Balance -= amount;
            return true;
        }

        public bool ReceiveMoney(double amount)
        {
            if (amount < 0) return false;

            Balance += amount;
            return true;

        }


    }
}
