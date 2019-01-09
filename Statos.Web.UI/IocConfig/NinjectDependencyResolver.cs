using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Statos.Model.Accounts;
using Statos.Model.Blogs;
using Statos.Model.Contacts;
using Statos.Model.Languages;
using Statos.Model.Members;
using Statos.Model.Products;
using Statos.Model.Stores;
using Statos.Model.Contents;
using Statos.Repository.Accounts;
using Statos.Repository.Blogs;
using Statos.Repository.Contacts;
using Statos.Repository.Languages;
using Statos.Repository.Members;
using Statos.Repository.Products;
using Statos.Repository.Stores;
using Statos.Repository.Contents;
using Statos.Service.Accounts;
using Statos.Service.Blogs;
using Statos.Service.Contacts;
using Statos.Service.Contents;
using Statos.Service.Languages;
using Statos.Service.Members;
using Statos.Service.Products;
using Statos.Service.Stores;

namespace Statos.Web.UI.IocConfig
{
    public class NinjectDependencyResolver : DefaultControllerFactory
    {
        private static IKernel _ninjectKernel;

        public NinjectDependencyResolver()
        {
            _ninjectKernel = new StandardKernel();
            ConfigurDepndency();
        }

        protected override IController GetControllerInstance(RequestContext requestContext ,Type controllerType)
        {
            return controllerType == null ? null : (IController) _ninjectKernel.Get(controllerType);
        }

      

        private static void ConfigurDepndency()
        {

           //Product
            _ninjectKernel.Bind<IProductService>().To<ProductService>();
            _ninjectKernel.Bind<IProductRepository>().To<ProductRepository>();

            //Contact
            _ninjectKernel.Bind<IContactService>().To<ContactService>();
            _ninjectKernel.Bind<IContactRepository>().To<ContactRepository>();

            //Store
            _ninjectKernel.Bind<IStoreService>().To<StoreService>();
            _ninjectKernel.Bind<IStoreRepository>().To<StoreRepository>();

            //Content 
            _ninjectKernel.Bind<IContentService>().To<ContentService>();
            _ninjectKernel.Bind<IContentRepository>().To<ContentRepository>();

            //Accunt
            _ninjectKernel.Bind<IAccountRepository>().To<AccountRepository>();
            _ninjectKernel.Bind<IAccountService>().To<AccountService>();

            //Blog
            _ninjectKernel.Bind<IBlogRepository>().To<BlogRepository>();
            _ninjectKernel.Bind<IBlogService>().To<BlogService>();
           
            //Member
            _ninjectKernel.Bind<IMemberRepository>().To<MemberRepository>();
            _ninjectKernel.Bind<IMemberService>().To<MemberService>();

            //Language
            _ninjectKernel.Bind<ILanguageRepository>().To<LanguageRepository>();
            _ninjectKernel.Bind<ILanguageService>().To<LanguageService>();

        }
    }
}
