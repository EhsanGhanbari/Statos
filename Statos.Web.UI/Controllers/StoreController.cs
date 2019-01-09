using System;
using System.Web.Mvc;
using Statos.Service.Products;
using Statos.Service.Stores;

namespace Statos.Web.UI.Controllers
{
    ///[Authorize]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;
        private readonly IProductService _productService;

        public StoreController(IStoreService storeService,IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
        }



        /// <summary>
        /// List Action to List the all products in Store
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var store = _storeService.GetAllStoreContent();
            return View("List",store);
        }



        /// <summary>
        /// Update Store stuff 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public ActionResult Update(Guid storeId)
        {
            var storeViewModel = new StoreViewModel {StoreId = storeId};
            var store = _storeService.GetStoreContentBy(storeViewModel);
            return View(store);
        }

        [HttpPost]
        public ActionResult Update(StoreViewModel storeViewModel)
        {
            if(ModelState.IsValid)
            {
                _storeService.EditStoreContent(storeViewModel);
            }
            return View();
        }


        /// <summary>
        /// Remove a product from store
        /// PopUp Modal
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(Guid storId)
        {
            var storeViewModel = new StoreViewModel {StoreId = storId};
            var store = _storeService.GetStoreContentBy(storeViewModel);
            return View("Delete",store);
        }


        [HttpPost]
        public ActionResult Delete(StoreViewModel storeViewModel)
        {
            if (ModelState.IsValid)
            {
                _storeService.RemoveStoreContent(storeViewModel);
            }
            return View("Delete");
        }
    }
}
