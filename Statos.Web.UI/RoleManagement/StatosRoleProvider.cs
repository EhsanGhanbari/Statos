using System;
using System.Linq;
using System.Web.Security;
using Statos.Repository;

namespace Statos.Web.UI.RoleManagement
{
    /// <summary>
    /// http://www.mattwrock.com/post/2009/10/14/Implementing-custom-Membership-Provider-and-Role-Provider-for-Authinticating-ASPNET-MVC-Applications.aspx
    /// </summary>
    public class StatosRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            using (var statosContext = new StatosContext())
            {
                var user = statosContext.Account.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return false;
                return user.UserRoles != null && user.UserRoles.Select(
                     u => u.Role).Any(r => r.RoleName == roleName);
            }
        }


        public override string[] GetRolesForUser(string username)
        {
            using (var statosContext = new StatosContext())
            {
                var user = statosContext.Account.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return new string[] { };
                return user.UserRoles == null ? new string[] { } :
                  user.UserRoles.Select(u => u.Role).Select(u => u.RoleName).ToArray();
            }
        }


        public override string[] GetAllRoles()
        {
            using (var statosContext = new StatosContext())
            {
                return statosContext.Roles.Select(r => r.RoleName).ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

     
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}