using System;
using System.Web.Mvc;
using Statos.Service.Categories;
using Statos.Service.Products;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService _productService;

        public CategoryController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// Returns All List of Categories
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            var category=_productService.GetAllCategories();
            return View("List",category);
        }


        /// <summary>
        /// Add Category action
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Cerate(CategoryViewModel categoryViewModel)
        {
            if(ModelState.IsValid)
            {
                 _productService.CreateCategory(categoryViewModel);
                 return RedirectToAction("List");
            }
            return View("Create");
        }
      

        /// <summary>
        /// Select a category and delete
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int categoryId)
        {
            if(ModelState.IsValid)
            {
                _productService.RemoveCategory(categoryId);
                RedirectToAction("List");
            }
            return Json("List");
           
        }

    }
}
