using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.customer
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
    }

    public class CustomerCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Nit { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int CategoryId { get; set; }
    }

    public class CustomerUpdateDTO
    {
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }
    }
}
