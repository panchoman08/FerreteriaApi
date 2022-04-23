using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class TranStatus
    {
        public TranStatus()
        {
            Sales = new HashSet<Sale>();
        }

        public byte Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
