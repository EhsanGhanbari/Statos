using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Statos.Model.Accounts
{
    public class Account : IAggregateRoot
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityEmail { get; set; }
        public string Sex { get; set; }
        public string  PhoneNumber { get; set; }
        public string  MobileNumber { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

    }
}
