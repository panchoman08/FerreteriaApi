using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Buys = new HashSet<Buy>();
        }

        public int Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int CategoryId { get; set; }

        public virtual SupplierCat Category { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
    }
}
