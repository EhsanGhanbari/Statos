using System.Collections.Generic;
using Statos.Model.Contents;

namespace Statos.Service.Contents
{
    public interface IContentService
    {
        void CreateContent(ContentViewModel contentViewModel);
        ContentViewModel GetLatestContent();
        Content UpdateContent(ContentViewModel contentViewModel);
        IEnumerable<ContentViewModel> GetAllContent();
        void RemoveContent(ContentViewModel contentViewModel);
    }
}
