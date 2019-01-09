using System;
using System.Collections.Generic;
using Statos.Model.Accounts;

namespace Statos.Service.Accounts
{
    public interface IAccountService
    {
        Account CreateAccount(AccountViewModel registerViewModel);
        Account  UpdateAccount(AccountViewModel accountViewModel);
        Account ResetPassword(AccountViewModel passwordViewModel);
        AccountViewModel GetAccount(int accountId);
        IEnumerable<AccountViewModel> GetAllAccounts();
        void RemoveAccount(int accountId);
    }
}
