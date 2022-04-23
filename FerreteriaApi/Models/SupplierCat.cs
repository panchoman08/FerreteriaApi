using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class SupplierCat
    {
        public SupplierCat()
        {
            Suppliers = new HashSet<Supplier>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
