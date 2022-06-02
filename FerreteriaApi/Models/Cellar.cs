using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class Cellar
    {
        public Cellar()
        {
            CellarTransferCellarDestinations = new HashSet<CellarTransfer>();
            CellarTransferCellarOrigins = new HashSet<CellarTransfer>();
            MinMaxProds = new HashSet<MinMaxProd>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<CellarTransfer> CellarTransferCellarDestinations { get; set; }
        public virtual ICollection<CellarTransfer> CellarTransferCellarOrigins { get; set; }
        public virtual ICollection<MinMaxProd> MinMaxProds { get; set; }
    }
}
