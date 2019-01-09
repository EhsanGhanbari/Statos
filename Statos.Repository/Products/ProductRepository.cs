using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Statos.Model.Products;

namespace Statos.Repository.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        
        private readonly StatosContext _statosContext;

        public ProductRepository(StatosContext statosContext)
            : base(statosContext)
        {
            _statosContext = statosContext;
        }


        #region Products

        /// <summary>
        /// Returns All Products By Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public IEnumerable<Product> FindAllProductsByCategory(int categoryId)
        {
            var query =
                _statosContext.Product.Where(p => p.Categories.Any(c => c.Id == categoryId)).OrderByDescending(p => p.CreationTime);

            return query.ToList();
        }


        /// <summary>
        /// Returns the recent products based on requested number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public IEnumerable<Product> FindRecentProducts(int number)
        {
            return _statosContext.Product.OrderByDescending(p => p.CreationTime).Take(number).ToList();
        }


        /// <summary>
        /// returns Products by brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        public IEnumerable<Product> FindAllProductsByBrand(int brandId)
        {
            var query = _statosContext.Product.Where(p => p.Brand.Id == brandId).OrderByDescending(p => p.CreationTime);
            return query.ToList();
        }

        #endregion

        #region Categories

        public IEnumerable<Category> FindAllCategories()
        {
            return _statosContext.Category.AsEnumerable();
        }

        #endregion


        #region Brands

        public IEnumerable<Brand> FindAllBrands()
        {
            return _statosContext.Brand.AsEnumerable();
        }

        #endregion

    }
}
