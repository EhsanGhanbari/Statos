using PagedList;
using Statos.Model.Products;

namespace Statos.Web.UI.ViewModels
{
    public class SearchViewModel
    {
        public int? Page { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public IPagedList<Product> SearchResults { get; set; }
    }
}