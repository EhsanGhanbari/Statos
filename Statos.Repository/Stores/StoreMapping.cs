using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Stores;

namespace Statos.Repository.Stores
{
    public class StoreMapping : EntityTypeConfiguration<Store>
    {
        public StoreMapping()
        {
            ToTable("Store");
            HasKey(s => s.Id);
            Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.NumberOfProduct).IsRequired();
            Property(s => s.Price).IsOptional();
            Property(s => s.TotalPrice).IsOptional();
            Property(s => s.PurchaseTime).IsRequired();
            Property(s => s.PurchaserName).IsOptional();
            HasRequired(s => s.Products).WithOptional();
            
        }
    }
}
