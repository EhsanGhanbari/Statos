using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Statos.Service.Categories;
using Statos.Service.Products;
using Statos.Service.Stores;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;

        public StoreController(IStoreService storeService,
            IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
        }


        /// <summary>
        /// List action returns All stuff in Store separetely by every products detail
        /// </summary>
        /// <returns></returns>
        public ViewResult List()
        {
            var store = _storeService.GetAllStoreContent();
            return View(store);
        }



        /// <summary>
        /// Add Action help Admin to Add a product to store !
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.country = from c in CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures).OrderBy(c => c.Name)
                              select new SelectListItem
                              {
                                  Text = c.EnglishName,
                                  Value = c.DisplayName
                              };

            ViewBag.Products = new SelectList(_productService.GetAllProducts(), "ProductId", "Name");


            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(StoreViewModel storeViewModel)
        {
            if (ModelState.IsValid)
            {
                _storeService.AddStoreContent(storeViewModel);
            }
            return View();
        }



        /// <summary>
        /// Edit action gets a product and make admin able to Edit a product content in store
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(Guid storeId)
        {
            var storeViewModel = new StoreViewModel { StoreId = storeId };
            var store = _storeService.GetStoreContentBy(storeViewModel);
            return View(store);
        }

        [HttpPost]
        public ActionResult Edit(StoreViewModel storeViewModel)
        {
            if (ModelState.IsValid)
            {
                _storeService.EditStoreContent(storeViewModel);
            }
            return View();
        }


        /// <summary>
        /// Remove method called via ajax and removes a product from store
        /// </summary>
        [HttpPost]
        public void Remove(Guid storeid)
        {
            var storeViewModel = new StoreViewModel { StoreId = storeid };
            if (ModelState.IsValid)
            {
                _storeService.RemoveStoreContent(storeViewModel);
            }
        }
    }
}
