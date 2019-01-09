using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Members;

namespace Statos.Repository.Members
{
    public class MemberMapping : EntityTypeConfiguration<Member>
    {
        public MemberMapping()
        {
            ToTable("Member");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Email).HasMaxLength(80);
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
