using AutoMapper;
using Statos.Model.Accounts;
using Statos.Model.Blogs;
using Statos.Model.Contacts;
using Statos.Model.Contents;
using Statos.Model.Members;
using Statos.Model.Products;
using Statos.Model.Stores;
using Statos.Service.Accounts;
using Statos.Service.Blogs;
using Statos.Service.Categories;
using Statos.Service.Contacts;
using Statos.Service.Contents;
using Statos.Service.Members;
using Statos.Service.Products;
using Statos.Service.Stores;

namespace Statos.Service
{
    public static class AutoMapperBootStrapper
    {
        public static void ConfigureAutoMapper()
        {
            
            //Product
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, Product>();


            //Category
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CategoryViewModel, Category>();
        


            //Contact
            Mapper.CreateMap<Contact, ContactViewModel>();
            Mapper.CreateMap<ContactViewModel, Contact>();


            //Store
            Mapper.CreateMap<Store, StoreViewModel>();
            Mapper.CreateMap<StoreViewModel, Store>();


            //Content
            Mapper.CreateMap<Content, ContentViewModel>();
            Mapper.CreateMap<ContentViewModel, Content>();

            
            //Account
            Mapper.CreateMap<Account, AccountViewModel>();
            Mapper.CreateMap<AccountViewModel, Account>();


            //Blog
            Mapper.CreateMap<Blog, BlogViewModel>();
            Mapper.CreateMap<BlogViewModel, Blog>();
           

            //Member 
            Mapper.CreateMap<Member, MemberViewModel>();
            Mapper.CreateMap<MemberViewModel, Member>();


            //Brands
            Mapper.CreateMap<Brand, BrandViewModel>();
            Mapper.CreateMap<BrandViewModel, Brand>();
        }
    }
}
