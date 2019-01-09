using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statos.Model.Blogs
{
    public class Blog : IAggregateRoot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlSlug { get; set; }
        public string Body { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
