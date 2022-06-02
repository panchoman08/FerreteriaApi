using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class UserSy
    {
        public UserSy()
        {
            Buys = new HashSet<Buy>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RolId { get; set; }
        public string Email { get; set; }

        public virtual RolUser Rol { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
