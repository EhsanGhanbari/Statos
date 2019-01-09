using System.Collections.Generic;
using System.Linq;
using Statos.Model.Blogs;

namespace Statos.Repository.Blogs
{
    public class BlogRepository :Repository<Blog>, IBlogRepository
    {
        private readonly StatosContext _statosContext;

        public BlogRepository(StatosContext statosContext) 
            : base(statosContext)
        {
            _statosContext = statosContext;
        }


        /// <summary>
        /// Returns the last 5 post 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<Blog> FindRecentPost(int number)
        {
            return _statosContext.Blog.OrderByDescending(b => b.CreationTime).Take(number).ToList();
        }
    }
}
