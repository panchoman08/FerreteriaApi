using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class ProductStum
    {
        public ProductStum()
        {
            Products = new HashSet<Product>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
