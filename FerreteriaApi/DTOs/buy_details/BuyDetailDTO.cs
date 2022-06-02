using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.buy_details
{
    public class BuyDetailDTO
    {
        public int Id { get; set; }
        //public int IdProduct { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Units { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }

    }

    public class BuyDetailCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Units { get; set; }
        public double Discount { get; set; }
        public double SubTotal { get; set; }

    }

    public class BuyDetailUpdateDTO
    {
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }

    }
}
