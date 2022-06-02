using System.ComponentModel.DataAnnotations;

namespace FerreteriaApi.DTOs.user_sys
{
    public class UserLogin
    {
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} must not be empty.")]
        public string Password { get; set; }
    }

    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
    }

   

}
