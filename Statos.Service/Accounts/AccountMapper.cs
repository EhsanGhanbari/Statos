using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Statos.Model.Accounts;

namespace Statos.Service.Accounts
{
    public static class AccountMapper
    {

        /// <summary>
        /// Convert Account Model to View Models
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static AccountViewModel ConvertToAccountViewModel(this Account account)
        {
            Mapper.CreateMap<Account, AccountViewModel>()
                  .ForMember(acc => acc.AccountId, ac => ac.MapFrom(a => a.Id));
            return Mapper.Map<Account, AccountViewModel>(account);
        }


        /// <summary>
        /// Convert to Account Model
        /// </summary>
        /// <param name="accountViewModel"></param>
        /// <returns></returns>
        public static Account ConvertToAccountModel(this AccountViewModel accountViewModel)
        {
            Mapper.CreateMap<AccountViewModel, Account>()
                    .ForMember(acc => acc.Id, ac => ac.MapFrom(a => a.AccountId));
            return Mapper.Map<AccountViewModel, Account>(accountViewModel);
        }

        /// <summary>
        /// Convert to Account View Model List Extension Method
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IEnumerable<AccountViewModel> ConvertToAccountListViewModel(this IEnumerable<Account> accounts)
        {
            Mapper.CreateMap<Account, AccountViewModel>()
               .ForMember(acc => acc.AccountId, ac => ac.MapFrom(a => a.Id));
            return Mapper.Map<IEnumerable<Account>, IEnumerable<AccountViewModel>>(accounts);
        }
        

        /// <summary>
        /// Convert to account list Model
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public static IEnumerable<Account> ConvertToAccountListModel(this IEnumerable<AccountViewModel> accounts)
        {
            return Mapper.Map<IEnumerable<AccountViewModel>, IEnumerable<Account>>(accounts);
        }
    }
}
