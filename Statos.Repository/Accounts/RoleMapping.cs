using System.Data.Entity.ModelConfiguration;
using Statos.Model.Accounts;

namespace Statos.Repository.Accounts
{
    public class RoleMapping:EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            
        }
    }
}
