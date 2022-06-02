using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.product
{
    public class CreateProductDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? BuyPrice { get; set; }
        public int? Stock { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public byte? StatusId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int? MeasureId { get; set; }

    }
}
