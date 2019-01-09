using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Contacts;

namespace Statos.Repository.Contacts
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            ToTable("Contact");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsOptional().HasMaxLength(40);
            Property(c => c.Title).IsRequired();
            Property(c => c.Body).IsRequired();
            Property(c => c.Email).IsRequired().HasMaxLength(80);
            Property(c => c.CreationTime).IsRequired();
            Property(c => c.ReplyMessage).IsOptional();
         //   Property(c => c.ReplyCreationDate).IsRequired();
        }

    }
}
