using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.user_sys_category
{
    public class UserRolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserRolCreateDTO
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Name { get; set; }
    }

    public class UserRolUpdateDTO
    {
        public string Name { get; set; }
    }
}
