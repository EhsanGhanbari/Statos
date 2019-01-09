using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Statos.Service.Categories;
using Statos.Service.Products;

namespace Statos.Web.UI.Areas.Manage.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
      

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// returns the list of all products 
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            var productList = _productService.GetAllProducts();
            return View(productList);
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
        /// Brows Product by category
        /// </summary>
        /// <returns></returns>
        public ActionResult ByCategory(int categoryId)
        {
            var products = _productService.GetAllProductsByCategory(categoryId);
            return View(products);
        }


        /// <summary>
        /// returns the all category to show in side bar
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult CategoryList()
        {
            var category = _productService.GetAllCategories();
            return PartialView("_CategoryListSideBar", category);
        }


        /// <summary>
        /// returns the all brands to show in side bar
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult BrandList()
        {
            var brands = _productService.GetAllBrands();
            return PartialView("_BrandListSidebar", brands);
        }


        /// <summary>
        /// Brows product by brand
        /// </summary>
        /// <returns></returns>
        public ActionResult ByBrand(int brandId)
        {
            var products = _productService.GetAllProductstByBrand(brandId);
            return View(products);
        }

        /// <summary>
        /// Create Category action
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var categoryitems =
                     _productService.GetAllCategories().Select(c => new SelectListItem
                     {
                         Value = c.CategoryId.ToString(),
                         Text = c.Name
                     });
            var brandItems =
                _productService.GetAllBrands().Select(b => new SelectListItem
                    {
                        Value = b.BrandId.ToString(),
                        Text = b.Name
                    });

            ViewBag.Categories = categoryitems;
            ViewBag.Brands = brandItems;
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel productViewModel, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid)
            {
                var filePath = FileUpload(uploadFile);

                productViewModel.Picture = filePath;
                _productService.CreateProduct(productViewModel);

                return RedirectToAction("List");
            }
            return View("Create");
        }


        /// <summary>
        /// Remove Product By Id
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Remove(int productId)
        {
            if (ModelState.IsValid)
            {
                _productService.RemoveProduct(productId);
                RedirectToAction("List");
            }
            return Json("");
        }


        /// <summary>
        /// Update Product By it's Identity
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ActionResult Edit(int productId)
        {

            var categoryitems =
                    _productService.GetAllCategories().Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.Name
                    });
            var brandItems =
                _productService.GetAllBrands().Select(b => new SelectListItem
                {
                    Value = b.BrandId.ToString(),
                    Text = b.Name
                });
            var product = _productService.GetProduct(productId);
            ViewBag.Categories = categoryitems;
            ViewBag.Brands = brandItems;
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(productViewModel);
                return RedirectToAction("List");
            }
            return View();
        }




        /// <summary>
        /// Uploading a file in a folder 
        /// mostly used for images of the products!
        /// this creates a folder by category name in images folder
        /// every category should has a folder contained images
        /// </summary>
        private string FileUpload(HttpPostedFileBase uploadFile)
        {
            //string id = Guid.NewGuid().ToString();
            //uploadFile.FileName = id;
            if (uploadFile.ContentLength > 0)
            {
                string filePath = Path.Combine(HttpContext.Server.MapPath("~/Images"),
                                               Path.GetFileName(uploadFile.FileName));
                uploadFile.SaveAs(filePath);
                return filePath;
            }
            return null;
        }
    }
}
