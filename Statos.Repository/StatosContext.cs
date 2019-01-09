using System.Data.Entity;
using Statos.Model.Accounts;
using Statos.Model.Blogs;
using Statos.Model.Contacts;
using Statos.Model.Contents;
using Statos.Model.Languages;
using Statos.Model.Members;
using Statos.Model.Products;
using Statos.Model.Stores;
using Statos.Repository.Accounts;
using Statos.Repository.Blogs;
using Statos.Repository.Contacts;
using Statos.Repository.Contents;
using Statos.Repository.Languages;
using Statos.Repository.Members;
using Statos.Repository.Products;
using Statos.Repository.Stores;

namespace Statos.Repository
{
    public class StatosContext : DbContext
    {
        public StatosContext()
        {
            if (Database.Exists() && !Database.CompatibleWithModel(false))
                Database.Delete();
            if (!Database.Exists()) Database.Create();
        }

        public StatosContext(string connectionString)
            : base(connectionString)
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AccountMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new UserRoleMapping());
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new StoreMapping());
            modelBuilder.Configurations.Add(new ContentMapping());
            modelBuilder.Configurations.Add(new BlogMapping());
            modelBuilder.Configurations.Add(new MemberMapping());
            modelBuilder.Configurations.Add(new BrandMapping());
            modelBuilder.Configurations.Add(new LanguageMapping());

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}
