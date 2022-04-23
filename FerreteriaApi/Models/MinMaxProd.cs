using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class MinMaxProd
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Minimm { get; set; }
        public int Maximum { get; set; }
        public int IdCellar { get; set; }

        public virtual Cellar IdCellarNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
