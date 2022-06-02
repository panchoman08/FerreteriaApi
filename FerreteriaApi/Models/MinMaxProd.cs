using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class MinMaxProd
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Minimm { get; set; }
        public int Maximum { get; set; }
        public int CellarId { get; set; }

        public virtual Cellar Cellar { get; set; }
        public virtual Product Product { get; set; }
    }
}
