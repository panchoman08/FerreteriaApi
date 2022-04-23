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
        public int IdCategory { get; set; }

        public virtual CustomerCat IdCategoryNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
