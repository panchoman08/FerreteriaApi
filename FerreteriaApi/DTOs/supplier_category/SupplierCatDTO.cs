using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.supplier_category
{
    public class SupplierCatDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SupplierCatCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class SupplierCatUpdateDTO
    {
        public string Name { get; set; }
    }
}
