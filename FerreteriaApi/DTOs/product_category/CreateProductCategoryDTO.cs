using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.product_category
{
    public class ProductCategoryCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class ProductCategoryUpdateDTO
    {
        public string Name { get; set; }
    }
}
