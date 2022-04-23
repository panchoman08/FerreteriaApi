using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.product
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? BuyPrice { get; set; }
        public int? Stock { get; set; }
        public int? IdCategory { get; set; }
        public byte? IdStatus { get; set; }
        public int? IdMeasure { get; set; }
    }

    public class ProductUpdateDTO
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? BuyPrice { get; set; }
        public int? Stock { get; set; }
        public int? IdCategory { get; set; }
        public byte? IdStatus { get; set; }
        public int? IdMeasure { get; set; }
    }
}
