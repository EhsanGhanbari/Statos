using System;
using System.Collections.Generic;

namespace Statos.Model.Products
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> FindAllProductsByCategory(int categoryId);
        IEnumerable<Product> FindRecentProducts(int number);
        IEnumerable<Product> FindAllProductsByBrand(int brandId);
        IEnumerable<Brand> FindAllBrands();
        IEnumerable<Category> FindAllCategories();
    }
}
