using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Buy
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual UserSy User { get; set; }
    }
}
