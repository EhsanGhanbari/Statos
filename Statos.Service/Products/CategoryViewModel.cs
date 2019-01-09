using System;
using System.ComponentModel.DataAnnotations;

namespace Statos.Service.Categories
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
