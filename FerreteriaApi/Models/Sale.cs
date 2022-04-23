using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdUser { get; set; }
        public byte IdTranStatus { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual TranStatus IdTranStatusNavigation { get; set; }
        public virtual UserSy IdUserNavigation { get; set; }
    }
}
