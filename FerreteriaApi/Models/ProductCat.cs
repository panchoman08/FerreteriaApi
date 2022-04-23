using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class ProductCat
    {
        public ProductCat()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
