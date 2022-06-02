using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public byte TranStatusId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public string NoDoc { get; set; }
        public string Serie { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual TranStatus TranStatus { get; set; }
        public virtual UserSy User { get; set; }
    }
}
