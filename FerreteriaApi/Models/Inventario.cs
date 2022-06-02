using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CellarId { get; set; }
        public int? BuyId { get; set; }
        public int? SaleId { get; set; }
        public int? CellarTransId { get; set; }
        public int? Units { get; set; }
    }
}
