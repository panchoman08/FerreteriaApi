using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.user_sys
{
    public class UserRegister
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        [MinLength(6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        [MinLength(6)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} must not be empty.")]
        public int IdRol { get; set; }
    }
}
