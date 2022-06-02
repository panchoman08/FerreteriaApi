using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Product
    {
        public Product()
        {
            BuyDets = new HashSet<BuyDet>();
            MinMaxProds = new HashSet<MinMaxProd>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? BuyPrice { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public byte? StatusId { get; set; }
        public int? MeasureId { get; set; }

        public virtual ProductCat Category { get; set; }
        public virtual Measure Measure { get; set; }
        public virtual ProductStum Status { get; set; }
        public virtual ICollection<BuyDet> BuyDets { get; set; }
        public virtual ICollection<MinMaxProd> MinMaxProds { get; set; }
    }
}
