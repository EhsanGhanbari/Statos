using System.Web;
using System.Web.Mvc;
using FluentSecurity;
using Statos.Web.UI.Areas.Manage.Controllers;

namespace Statos.Web.UI.Security
{
    public static class FluentSecurity
    {
        public static void Configure()
        {
            SecurityConfigurator.Configure(configuration =>
            {
                // Let FluentSecurity know how to get the authentication status of the current user
                configuration.GetAuthenticationStatusFrom(() => HttpContext.Current.User.Identity.IsAuthenticated);

                configuration.IgnoreMissingConfiguration();

                // This is where you set up the policies you want FluentSecurity to enforce on your controllers and actions
                configuration.For<HomeController>().Ignore();
                configuration.For<HomeController>().Ignore();
                configuration.For<AccountController>().DenyAuthenticatedAccess();
                //  configuration.For<AccountController>(x => x.ChangePassword()).DenyAnonymousAccess();
                //  configuration.For<AccountController>(x => x.LogOff()).DenyAnonymousAccess();
               // configuration.For<StoreController>().RequireRole(roles:)
            });

            GlobalFilters.Filters.Add(new HandleSecurityAttribute(), 0);
        }
    }
}