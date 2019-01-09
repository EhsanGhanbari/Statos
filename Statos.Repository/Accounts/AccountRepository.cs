using Statos.Model.Accounts;

namespace Statos.Repository.Accounts
{
    public class AccountRepository:Repository<Account>,IAccountRepository
    {
        public AccountRepository(StatosContext statosContext) : base(statosContext)
        {
        }
    }
}
