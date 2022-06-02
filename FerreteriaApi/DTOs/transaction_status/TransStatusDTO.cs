using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.transaction_status
{
    public class TransStatusDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class TransStatusCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Description { get; set; }
    }

    public class TransStatusUpdateDTO
    {
        public string Description { get; set; }
    }
}
