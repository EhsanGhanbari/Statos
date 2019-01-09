using System;
using System.Collections.Generic;
using Statos.Model.Accounts;

namespace Statos.Service.Accounts
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        /// <summary>
        /// Create Account Method
        /// </summary>
        /// <param name="registerViewModel"></param>
        /// <returns></returns>
        public Account CreateAccount(AccountViewModel registerViewModel)
        {
            var account = registerViewModel.ConvertToAccountModel();
            account.CreationTime = DateTime.Now;
            _accountRepository.Add(account);
            _accountRepository.SaveChanges();
            return account;
        }


        /// <summary>
        /// Update Account Details
        /// </summary>
        /// <param name="accountViewModel"></param>
        /// <returns></returns>
        public Account UpdateAccount(AccountViewModel accountViewModel)
        {
            var account = accountViewModel.ConvertToAccountModel();
            account.CreationTime = DateTime.Now;
            _accountRepository.Update(account);
            _accountRepository.SaveChanges();
            return account;
        }


        /// <summary>
        /// Reset Password Method !
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns></returns>
        public Account ResetPassword(AccountViewModel passwordViewModel)
        {
            var account = passwordViewModel.ConvertToAccountModel();
            account.CreationTime = DateTime.Now;
            _accountRepository.Update(account);
            _accountRepository.SaveChanges();
            return account;
        }


        /// <summary>
        /// Get an Account by it's Identity
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public AccountViewModel GetAccount(int accountId)
        {
            var account = _accountRepository.FindBy(accountId);
            var accountView = account.ConvertToAccountViewModel();
            return accountView;
        }


        /// <summary>
        /// Get All Account 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountViewModel> GetAllAccounts()
        {
            var account = _accountRepository.GetAll();
            var accountViewModelList = account.ConvertToAccountListViewModel();
            return accountViewModelList;
        }


        /// <summary>
        /// Remove Account By it's Identity
        /// </summary>
        /// <param name="accountId"></param>
        public void RemoveAccount(int accountId)
        {
            var accountView = new AccountViewModel {AccountId = accountId};
            var account = accountView.ConvertToAccountModel();
            _accountRepository.Delete(account);
            _accountRepository.FindBy();
        }
    }
}
