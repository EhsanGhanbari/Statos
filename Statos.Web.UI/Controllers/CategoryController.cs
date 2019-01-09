using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Categories;
using Statos.Service.Products;

namespace Statos.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// returns list of all category in the system
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var categories = _productService.GetAllCategories();
            return View(categories);
        }



        /// <summary>
        /// Returns the Products of a category
        /// </summary>
        /// <returns></returns>
        public ActionResult Products(int categoryId)
        {
            var products = _productService.GetAllProductsByCategory(categoryId);
            return View(products);
        }

      

        /// <summary>
        /// returns the Category Side bar in the View
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CategorySideBar()
        {
            var categries = _productService.GetAllCategories();
            return PartialView("CategorySideBar", categries);
        }

    }
}
