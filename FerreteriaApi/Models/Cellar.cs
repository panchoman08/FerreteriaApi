using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Cellar
    {
        public Cellar()
        {
            MinMaxProds = new HashSet<MinMaxProd>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<MinMaxProd> MinMaxProds { get; set; }
    }
}
