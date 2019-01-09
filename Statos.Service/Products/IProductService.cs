using System;
using System.Collections.Generic;
using Statos.Model.Products;
using Statos.Service.Categories;

namespace Statos.Service.Products
{
    public interface IProductService
    {
        #region Product
        IEnumerable<ProductViewModel> GetAllProducts();
        void CreateProduct(ProductViewModel productViewModel);
        ProductViewModel GetProduct(int productId);
        void UpdateProduct(ProductViewModel productViewModel);
        void RemoveProduct(int productId);
        IEnumerable<ProductViewModel> GetAllProductsByCategory(int categoryId);
        IEnumerable<ProductViewModel> GetLatestProducts();
        IEnumerable<ProductViewModel> GetAllProductstByBrand(int brandId);
        #endregion

        #region Brands
        void CreateBrand(BrandViewModel brandViewModel);
        IEnumerable<BrandViewModel> GetAllBrands();
        void RemoveBrand(int brandId);
        #endregion

        #region Category

        void CreateCategory(CategoryViewModel categoryViewModel);
        IEnumerable<CategoryViewModel> GetAllCategories();
        void RemoveCategory(int categoryId);
      
        #endregion
    }
}
