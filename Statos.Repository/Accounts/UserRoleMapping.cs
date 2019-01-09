using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Accounts;

namespace Statos.Repository.Accounts
{
    public class UserRoleMapping : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMapping()
        {
            ToTable("UserRole");
            HasKey(c => c.UserRoleId);
            Property(c => c.UserRoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



        }
    }
}
