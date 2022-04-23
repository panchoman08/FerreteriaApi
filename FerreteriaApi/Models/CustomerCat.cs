using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class CustomerCat
    {
        public CustomerCat()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
