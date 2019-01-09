using System;
using System.Collections.Generic;
using System.Linq;
using Statos.Model.Products;
using Statos.Service.Categories;

namespace Statos.Service.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;


        #region Products

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// returns all products of the system 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll().OrderByDescending(p => p.CreationTime);
            var productsList = products.ConvertToProductViewList();
            return productsList;
        }



        /// <summary>
        /// create a product by All of it's stuff 
        /// </summary>
        /// <returns></returns>
        public void CreateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ConvertToProductModel();
            product.CreationTime = DateTime.Now;
            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }



        /// <summary>
        /// returns product by it's id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductViewModel GetProduct(int productId)
        {
            var product = _productRepository.FindBy(productId);
            var productSelected = product.ConvertToProductViewModel();
            return productSelected;
        }


        /// <summary>
        /// Update product by Id
        /// </summary>
        /// <param name="productViewModel"></param>
        /// <returns></returns>
        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ConvertToProductModel();
            product.CreationTime = DateTime.Now;
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }



        /// <summary>
        /// remove product service method
        /// </summary>
        /// <param name="productId"></param>
        public void RemoveProduct(int productId)
        {
            var product = new Product { Id = productId };
            _productRepository.Delete(product);
            _productRepository.SaveChanges();
        }


        /// <summary>I
        /// get a product list by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetAllProductsByCategory(int categoryId)
        {
            var product = _productRepository.FindAllProductsByCategory(categoryId);
            var productView = product.ConvertToProductViewList();
            return productView;
        }



        /// <summary>
        /// Get latest 10 product to show in the main page
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetLatestProducts()
        {
            var products = _productRepository.FindRecentProducts(3);
            var productViewMode = products.ConvertToProductViewList();
            return productViewMode;
        }


        /// <summary>
        /// returns Products by Brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public IEnumerable<ProductViewModel> GetAllProductstByBrand(int brandId)
        {
            var brands = _productRepository.FindAllProductsByBrand(brandId);
            var brandsViewModel = brands.ConvertToProductViewList();
            return brandsViewModel;
        }

        #endregion

        #region Brand
        public void CreateBrand(BrandViewModel brandViewModel)
        {
            var brands = new List<Brand> 
            {
                new Brand
                {
                      Id = brandViewModel.BrandId,
                      Name = brandViewModel.Name
                }
            };

            var product = new Product(brands);
            _productRepository.Add(product);
            _productRepository.SaveChanges();
        }


        /// <summary>
        /// returns All brand of the website
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BrandViewModel> GetAllBrands()
        {
            var brands = _productRepository.FindAllBrands();
            var brandViewModel = brands.ConvertToBrandViewModelList();
            return brandViewModel;
        }


        /// <summary>
        /// Remove Brand By Identity
        /// </summary>
        /// <param name="brandId"></param>
        public void RemoveBrand(int brandId)
        {
            var brand = new Brand { Id = brandId };

            if (ModifyIfBrandIsRemovable(brandId))
            {
                //     _productRepository.Delete(brand);
                //       _brandRepository.SaveChanges();
            }
        }

        /// <summary>
        /// Modifies if brnad is removable or not
        /// if it belongs to a product or not
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public bool ModifyIfBrandIsRemovable(int brandId)
        {
            var brand = _productRepository.GetAll();
            return brand.All(item => item.BrandId != brandId);
        }

        #endregion

        #region Category

        /// <summary>
        /// Create Category Method
        /// </summary>
        /// <returns></returns>
        public void CreateCategory(CategoryViewModel categoryViewModel)
        {
            var categories = new List<Category>
            {
                new Category
                {
                  Id = categoryViewModel.CategoryId,
                  Name = categoryViewModel.Name     
                }
           };

            var product = new Product(categories);
            // product.AddCategory(ca);
            _productRepository.SaveChanges();
        }







        /// <summary>
        /// get All Category of the system! 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            var category = _productRepository.FindAllCategories();
            var categoryViewModel = category.ConvertToCategoryViewModelList();
            return categoryViewModel;
        }


        /// <summary>
        /// Remove Category by it's Id
        /// maybe it never will be used!
        /// </summary>
        /// <param name="categoryId"></param>
        public void RemoveCategory(int categoryId)
        {
            var category = new Category { Id = categoryId };

            if (ModifyIfCategoryIsRemovable(categoryId))
            {
                //_categoryRepository.Delete(category);
                //_categoryRepository.SaveChanges();
            }
        }


        /// <summary>
        /// Modify if category is removabl 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        private bool ModifyIfCategoryIsRemovable(int categoryId)
        {
            var brand = _productRepository.GetAll();
            return brand.All(item => item.Categories.All(c => c.Id != categoryId));
        }

        #endregion
    }
}