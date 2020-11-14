using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSupplierOwnership
    {
        public int OwnershipId { get; set; }
        public int SupplierId { get; set; }
        public string MainShareholder { get; set; }
        public decimal? Shareholding { get; set; }
        public int? CountryId { get; set; }

        public virtual TblCountry Country { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
