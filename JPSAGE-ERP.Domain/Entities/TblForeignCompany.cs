using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblForeignCompany
    {
        public int ForComId { get; set; }
        public string CompanyName { get; set; }
        public int ProductSupplied { get; set; }
        public int? Status { get; set; }
        public string Others { get; set; }
        public int SupplierId { get; set; }

        public virtual TblProducts ProductSuppliedNavigation { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
