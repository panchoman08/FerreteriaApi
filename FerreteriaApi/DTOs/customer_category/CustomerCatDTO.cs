using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.customer_category
{
    public class CustomerCatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CustomerCatCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class CustomerCatUpdateDTO
    {
        public string Name { get; set; }
    }
}
