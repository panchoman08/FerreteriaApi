using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.sale
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public byte TranStatusId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }

    }

    public class SaleCreateDTO
    {

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public byte TranStatusId { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string NoDoc { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Serie { get; set; }
    }

    public class SaleUpdateDTO
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public byte TranStatusId { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }
    }
}
