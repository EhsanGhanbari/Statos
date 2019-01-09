using System.Linq;
using System.Web.Mvc;
using PagedList;
using Statos.Repository;
using Statos.Web.UI.ViewModels;

namespace Statos.Web.UI.Controllers
{
    /// <summary>
    /// Search controller contains a search box and search View
    /// http://unboxedsolutions.com/Blog/Post/15977
    /// http://www.asp.net/mvc/tutorials/getting-started-with-ef-using-mvc/sorting-filtering-and-paging-with-the-entity-framework-in-an-asp-net-mvc-application
    /// </summary>
    public class SearchController : Controller
    {
        private const int RecordsPerPage = 25;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult SearchSideBar()
        {
            return PartialView("_SearchSideBar");
        }


        /// <summary>
        /// Advance Search is a 
        /// </summary>
        /// <returns></returns>
        public ActionResult Advanced(SearchViewModel searchViewModel)
        {
            if (ModelState.IsValid && string.IsNullOrEmpty(searchViewModel.ToString()))
            {
                var entities = new StatosContext();
                var results = entities.Product.Where(
                    s => s.Name.StartsWith(searchViewModel.ProductName) || s.Brand.Name.Equals(searchViewModel.Brand)
                        ||s.Categories.Any(c=>c.Name.Equals(searchViewModel.Category)))
                                      .OrderBy(o => o.CreationTime);

                var pageIndex = searchViewModel.Page ?? 0;
                searchViewModel.SearchResults = results.ToPagedList(pageIndex, 25);
            }
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchViewModel"></param>
        /// <returns></returns>
        public ActionResult List(SearchViewModel searchViewModel)
        {
            if (!string.IsNullOrEmpty(searchViewModel.ProductName))
            {
                var entities = new StatosContext();
                var results = entities.Product.Where(
                    c => c.Name.StartsWith(searchViewModel.ProductName))
                                      .OrderBy(o => o.CreationTime);

                var pageIndex = searchViewModel.Page ?? 0;
                searchViewModel.SearchResults = results.ToPagedList(pageIndex, 25);

                ViewBag.SearchParameters = searchViewModel;
            }
            return View(searchViewModel);
        }

    }
}
