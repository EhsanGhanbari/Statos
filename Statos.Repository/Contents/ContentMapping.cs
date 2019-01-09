using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Contents;

namespace Statos.Repository.Contents
{
    public class ContentMapping : EntityTypeConfiguration<Content>
    {
        public ContentMapping()
        {
            ToTable("Content");
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.CreationTime).IsRequired();
            Property(c => c.AboutText).IsMaxLength().IsOptional();
            Property(c => c.Address).HasMaxLength(300).IsOptional();
            Property(c => c.FaceBook).HasMaxLength(80);
            Property(c => c.GooglePlus).HasMaxLength(80);
            Property(c => c.HeaderImage).IsOptional();
            Property(c => c.Mobile).IsOptional();
            Property(c => c.Phone).IsOptional();
            Property(c => c.Twitter).HasMaxLength(80).IsOptional();
        }
    }
}
