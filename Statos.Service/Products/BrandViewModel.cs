using System;
using System.ComponentModel.DataAnnotations;

namespace Statos.Service.Products
{
    public class BrandViewModel
    {
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

    }
}
