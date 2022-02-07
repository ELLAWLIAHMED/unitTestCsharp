using Accounts_Core.Interfaces;
using Data_Access.Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data_Access.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        protected AccountDbContext _context;

        public AccountRepository(AccountDbContext context)
        {
            _context = context;
        }

        public bool DeleteAccount(long id)
        {
            try
            {
                Account account = GetAccountById(id);
                _context.Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
            
        }

        public Account FindAccount(Expression<Func<Account, bool>> expression)
        {
            Account account = _context.Accounts.Where(expression).FirstOrDefault();
            return account;
        }

        public Account GetAccountById(long id)
        {
            Account account = _context.Accounts.Find(id);
            if (account == null) throw new Exception("Account not found !");
            
            return account;
           
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accounts = _context.Accounts.ToList();
            return accounts;
        }

        public bool SaveAccount(Account account)
        {
            if (account != null && account.Rib.ToString().Length >0)
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
