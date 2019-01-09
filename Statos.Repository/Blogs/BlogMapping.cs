using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Statos.Model.Blogs;

namespace Statos.Repository.Blogs
{
    public class BlogMapping:EntityTypeConfiguration<Blog>
    {
        public BlogMapping()
        {
            ToTable("Blog");
            HasKey(b => b.Id);
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.CreationTime).IsRequired();
            Property(b => b.UrlSlug).IsRequired();
            Property(b => b.Body).IsRequired().IsMaxLength();
            Property(b => b.Title).IsRequired().HasMaxLength(200);
        }
    }
}
