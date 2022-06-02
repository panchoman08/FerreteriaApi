using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class BuyDet
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public int? Units { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }

        public virtual Product Product { get; set; }
    }
}
