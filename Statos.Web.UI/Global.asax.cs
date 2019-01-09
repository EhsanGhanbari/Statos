using System.Data.Entity;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Statos.Repository;
using Statos.Service;
using Statos.Web.UI.IocConfig;

namespace Statos.Web.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route to support Blog
            routes.MapRoute("BlogRoute",
                            "Post/{postId}/{urlSlug}",
                            new { controller = "Blog", action = "Post", postId = "", urlSlug="" },
                            new[] { "Statos.Web.UI.Controllers" });



            //Route to support Category 
            routes.MapRoute("CategoryRoute",
                            "Category/Products/{categoryId}",
                            new { controller = "Category", action = "Products", categoryId = "" },
                            new[] { "Statos.Web.UI.Controllers" });


            //Route to support Brand
            routes.MapRoute("BrandRoute",
                "Brand/Products/{brandId}",
                new { controller = "Brand", action = "Products", brandId = "" },
                new[] { "Statos.Web.UI.Controllers" });


            //Route to support Products
            routes.MapRoute("ProductRoute",
                "Product/Details/{productId}",
                new { controller = "Product", action = "Details", productId = "" },
                new[] { "Statos.Web.UI.Controllers" });



            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Statos.Web.UI.Controllers" });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            //Dependency Injection
            ControllerBuilder.Current.SetControllerFactory(new NinjectDependencyResolver());
            
            //Service Automapper
            AutoMapperBootStrapper.ConfigureAutoMapper();
            
            //DataBase Initializer
            Database.SetInitializer(new Initializer());
        }
        
        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            // Check for culture type of Machine
            if (custom == "culture")
            {
                return Thread.CurrentThread.CurrentCulture.Name;
            }
            return base.GetVaryByCustomString(context, custom);
        }
    }
}