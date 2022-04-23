using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class SaleDet
    {
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public int Units { get; set; }
        public decimal? Discount { get; set; }
        public decimal? SubTotal { get; set; }
    }
}
