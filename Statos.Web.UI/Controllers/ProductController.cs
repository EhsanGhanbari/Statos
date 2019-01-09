using System;
using System.Web.Mvc;
using PagedList;
using Statos.Service.Products;

namespace Statos.Web.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        /// <summary>
        /// Returns List of the Products
        /// </summary>
        /// <returns></returns>
        public ActionResult List(int? page)
        {
            var products = _productService.GetAllProducts();
            var pageNumber = page ?? 1;
            var onePageOfProducts = products.ToPagedList(pageNumber, 20);
            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View(products);
        }

        /// <summary>
        /// Returns the all Details of the Product
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(int productId)
        {
            var product = _productService.GetProduct(productId);
            return View("Detail", product);
        }
        
        /// <summary>
        /// Product Side bar that will show in the main page
        /// it Returns latest products of the system
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ProductSideBar()
        {
            var product = _productService.GetLatestProducts();
            return PartialView("ProductSideBar", product);
        }
    }
}
