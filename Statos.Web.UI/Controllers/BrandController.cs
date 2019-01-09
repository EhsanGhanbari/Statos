using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Products;

namespace Statos.Web.UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IProductService _productService;

        public BrandController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// List of all brands in the system
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var brands = _productService.GetAllBrands();
            return View(brands);
        }

        /// <summary>
        /// returns Products by brand action 
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public ActionResult Products(int brandId)
        {
            var products = _productService.GetAllProductstByBrand(brandId);
            return View("Products",products);
        }


        /// <summary>
        /// child action to show all brand in main menue
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult BrandSideBar()
        {
            var brands = _productService.GetAllBrands();
            return PartialView("BrandSideBar", brands);
        }

    }
}
