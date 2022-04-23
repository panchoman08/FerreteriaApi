using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.product_status
{
    public class ProductStatusCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class ProductStatusDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductStatusUpdateDTO
    {
        public string Name { get; set; }
    }
    
}
