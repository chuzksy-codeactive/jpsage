using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblTypicalSubcontractedScope
    {
        public int SubConScopeId { get; set; }
        public string SubConName { get; set; }
        public string SubConAddress { get; set; }
        public int? CountryId { get; set; }
        public int? SupplierId { get; set; }
        public int? ProductId { get; set; }
        public bool? IsLocal { get; set; }

        public virtual TblCountry Country { get; set; }
        public virtual TblProducts Product { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
