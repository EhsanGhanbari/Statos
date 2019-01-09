using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Products;

namespace Statos.Repository.Products
{
    public class BrandMapping :EntityTypeConfiguration<Brand>
    {
        public BrandMapping()
        {
            ToTable("Brand");
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name).IsOptional();
            Property(c => c.Name).IsRequired().HasMaxLength(40);
        }
    }
}
