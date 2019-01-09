using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Products;

namespace Statos.Repository.Products
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            ToTable("Product");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).IsRequired();
            Property(p => p.Price).IsOptional();
            Property(p => p.Description).IsOptional();
            Property(p => p.Description).IsOptional();
            Property(p => p.CreationTime).IsRequired();
            Property(p => p.Picture).IsOptional();

            HasRequired(p => p.Brand);

            //      HasMany(p => p.Brand)
            //.HasForeignKey(s => s.bran).WillCascadeOnDelete(false);

        }
    }
}
