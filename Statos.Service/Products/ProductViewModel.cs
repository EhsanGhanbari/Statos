using System;
using System.ComponentModel.DataAnnotations;
using Statos.Model.Products;

namespace Statos.Service.Products
{
    public class ProductViewModel 
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        [Required(ErrorMessage="Product Name is Empty")]
        public string Name { get; set; }

        
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public string Picture { get; set; }
        public Category Category { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
