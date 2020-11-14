using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSpDirectServiceScope
    {
        public int SpDssId { get; set; }
        public string SpServices { get; set; }
        public string Description { get; set; }
        public int? SupplierId { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
