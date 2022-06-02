using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class CellarTransfer
    {
        public CellarTransfer()
        {
            CellarTransferDets = new HashSet<CellarTransferDet>();
        }

        public int Id { get; set; }
        public string NoTransfer { get; set; }
        public int CellarOriginId { get; set; }
        public int CellarDestinationId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Cellar CellarDestination { get; set; }
        public virtual Cellar CellarOrigin { get; set; }
        public virtual ICollection<CellarTransferDet> CellarTransferDets { get; set; }
    }
}
