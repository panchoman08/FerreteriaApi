using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.cellar_transfer_details
{
    public class CellarTransferDetDTO
    {
        public int Id { get; set; }
        public int CellarTransId {get; set;}
        public int ProductId { get; set;}
        public int Units { get; set;}
    }

    public class CellarTransDetCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CellarTransId { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int ProductId { get; set; }
        public int Units { get; set; }
    }

    public class CellarTransDetUpdateDTO
    {
        public int CellarTransId { get; set; }
        public int ProductId { get; set; }
        public int? Units { get; set; }
    }
}
