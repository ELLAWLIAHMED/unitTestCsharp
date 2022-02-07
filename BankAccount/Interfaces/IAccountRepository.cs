using Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Accounts_Core.Interfaces
{
    public interface IAccountRepository
    {
        Account GetAccountById(long id);

        bool SaveAccount(Account account);

        IEnumerable<Account> GetAllAccounts();

        Account FindAccount(Expression<Func<Account, bool>> expression);

        bool DeleteAccount(long id);


    }
}
