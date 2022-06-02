using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.cellar
{
    public class CellarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

    }

    public class CellarCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
        public string Address { get; set; }

    }

    public class CellarUpdateDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
