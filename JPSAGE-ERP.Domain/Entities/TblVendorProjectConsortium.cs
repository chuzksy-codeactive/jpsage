using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblVendorProjectConsortium
    {
        public int VenProConId { get; set; }
        public int? SupplierId { get; set; }
        public string ProjectConsortiumName { get; set; }
        public string ProjectConsortiumAddress { get; set; }
        public string Services { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
