using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Product
    {
        public Product()
        {
            MinMaxProds = new HashSet<MinMaxProd>();
        }

        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? BuyPrice { get; set; }
        public int? Stock { get; set; }
        public int? IdCategory { get; set; }
        public byte? IdStatus { get; set; }
        public int? IdMeasure { get; set; }

        public virtual ProductCat IdCategoryNavigation { get; set; }
        public virtual Measure IdMeasureNavigation { get; set; }
        public virtual ProductStum IdStatusNavigation { get; set; }
        public virtual ICollection<MinMaxProd> MinMaxProds { get; set; }
    }
}
