using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statos.Model.Blogs
{
    public interface IBlogRepository : IRepository<Blog>
    {
        IEnumerable<Blog> FindRecentPost(int number);
    }
}
