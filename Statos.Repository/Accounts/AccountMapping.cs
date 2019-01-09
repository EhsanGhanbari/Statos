using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Accounts;

namespace Statos.Repository.Accounts
{
    public class AccountMapping :EntityTypeConfiguration<Account>
    {
        public AccountMapping()
        {
            ToTable("Account");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.FirstName).IsRequired().HasMaxLength(40);
            Property(c => c.LastName).IsRequired().HasMaxLength(40);
            Property(c => c.Email).IsRequired().HasMaxLength(80);
            Property(c => c.UserName).IsRequired().HasMaxLength(30);
            Property(c => c.Password).IsRequired().HasMaxLength(18);
            Property(c => c.SecurityEmail).IsRequired().HasMaxLength(80);
            Property(c => c.Sex).IsOptional();
            Property(c => c.CreationTime).IsRequired();
        }
    }
}
