using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblMainCustomers
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CountryId { get; set; }
        public int ValueId { get; set; }
        public int SupplierId { get; set; }

        public virtual TblCountry Country { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual TblValueDetails Value { get; set; }
    }
}
