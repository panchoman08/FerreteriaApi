using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.buy
{
    public class BuyDTO
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }

    }

    public class BuyCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public double Total { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string NoDoc { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Serie { get; set; }

    }

    public class BuyUpdateDTO
    {
        public int IdSupplier { get; set; }
        public int IdUser { get; set; }
        public DateTime Date { get; set; }
        public decimal? Total { get; set; }
        public string NoDoc { get; set; }

        public string Serie { get; set; }
    }
}
