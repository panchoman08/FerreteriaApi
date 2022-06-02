using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.cellar_transfer
{
    public class CellarTransferDTO
    {
        public int Id { get; set; }
        public string NoTransfer { get; set; }
        public int CellarOriginId { get; set; }
        public int CellarDestinationId { get; set; }
        public DateTime Date { get; set; }
    }

    public class CellarTransferCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string NoTransfer { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CellarOriginId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CellarDestinationId { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public DateTime Date { get; set; }
    }

    public class CellarTransferUpdateDTO
    {
        public string NoTransfer { get; set; }
        public int CellarOriginId { get; set; }
        public int CellarDestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}
