using Statos.Model.Contents;

namespace Statos.Model.Contents
{
    public interface IContentRepository : IRepository<Content>
    {
        Content GetLatestContentQuery();
    }
}
