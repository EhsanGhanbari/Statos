using System;
using System.Collections.Generic;

namespace Statos.Model.Products
{
    public class Product : IAggregateRoot
    {

        private readonly IList<Category> _category;
        private readonly IList<Brand> _brands;

        public Product()
        { }

        public Product(IList<Category> category)
        {
            _category = category;
        }

        public Product(IList<Brand> brands)
        {
            _brands = brands;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public string Picture { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return _category; }
        }



        #region Category

        public void AddCategory(Category category)
        {
            _category.Add(category);
        }
        #endregion


        #region

        public void AddBrand(Brand brand)
        {
            _brands.Add(brand);
        }


        #endregion
    }
}
