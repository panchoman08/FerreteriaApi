using System;
using System.Collections.Generic;

namespace FerreteriaApi.Models
{
    public partial class CellarTransferDet
    {
        public int Id { get; set; }
        public int CellarTransId { get; set; }
        public int ProductId { get; set; }
        public int? Units { get; set; }

        public virtual CellarTransfer CellarTrans { get; set; }
    }
}
