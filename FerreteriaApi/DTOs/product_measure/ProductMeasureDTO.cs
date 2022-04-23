using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.product_measure
{
    public class ProductMeasureDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductMeasureCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class ProductMeasureUpdateDTO
    {
        public string Name { get; set; }
    }
}
