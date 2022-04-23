using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Buy
    {
        public int Id { get; set; }
        public int IdSupplier { get; set; }
        public int IdUser { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }

        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual UserSy IdUserNavigation { get; set; }
    }
}
