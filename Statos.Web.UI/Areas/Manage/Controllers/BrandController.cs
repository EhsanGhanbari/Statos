using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Products;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class BrandController : Controller
    {
        private readonly IProductService _productService;

        public BrandController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Retusns the list of the Brands
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var brands = _productService.GetAllBrands();
            return View("List", brands);
        }


        /// <summary>
        /// Create brand
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                _productService.CreateBrand(brandViewModel);
                return RedirectToAction("List");
            }
            return View("Create");
        }


        /// <summary>
        /// Delete brand action!
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int brandId)
        {
            if (ModelState.IsValid)
            {
              _productService.RemoveBrand(brandId);
             
            }
            return RedirectToAction("List");
        }
    }
}

