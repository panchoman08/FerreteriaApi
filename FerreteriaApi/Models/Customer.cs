using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }

        public virtual CustomerCat Category { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
