using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.inventory
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public int BuyId { get; set; }
        public int SaleId { get; set; }
        public int CellarTransId { get; set; }
        public int Units { get; set; }
    }
    public class InventoryCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CellarId { get; set; }
        public int BuyId { get; set; }
        public int SaleId { get; set; }
        public int CellarTransId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int Units { get; set; }
    }

    public class InventoryUpdateDTO
    {
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public int BuyId { get; set; }
        public int SaleId { get; set; }
        public int CellarTransId { get; set; }
        public int Units { get; set; }
    }
}
