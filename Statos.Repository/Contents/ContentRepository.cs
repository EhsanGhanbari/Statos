using System.Linq;
using Statos.Model.Contents;

namespace Statos.Repository.Contents
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        private readonly StatosContext _statosContext;

        public ContentRepository(StatosContext statosContext)
            : base(statosContext)
        {
            _statosContext = statosContext;
        }


        /// <summary>
        /// returns the Default Content
        /// </summary>
        /// <returns></returns>
        public Content GetLatestContentQuery()
        {
            return _statosContext.Content.OrderByDescending(c => c.CreationTime).FirstOrDefault();
        }
    }
}
