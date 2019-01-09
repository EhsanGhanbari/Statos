using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statos.Model.Contacts
{
    public class Contact :IAggregateRoot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }

        public string ReplyMessage { get; set; }
      //  public DateTime ReplyCreationDate { get; set; }
    }
}
