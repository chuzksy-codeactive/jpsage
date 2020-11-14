using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCorporateDistinctives
    {
        public int CorpDisId { get; set; }
        public int SupplierId { get; set; }
        public string Details { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
