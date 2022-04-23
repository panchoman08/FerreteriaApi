using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class RolUser
    {
        public RolUser()
        {
            UserSies = new HashSet<UserSy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserSy> UserSies { get; set; }
    }
}
