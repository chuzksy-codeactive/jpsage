using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSubContractedServices
    {
        public TblSubContractedServices()
        {
            TblSubContractedDetails = new HashSet<TblSubContractedDetails>();
        }

        public int SubServId { get; set; }
        public decimal? PercentageOutsourced { get; set; }
        public int? SupplierId { get; set; }
        public int? ServiceId { get; set; }

        public virtual TblServices Service { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblSubContractedDetails> TblSubContractedDetails { get; set; }
    }
}
