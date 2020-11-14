using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblProducts
    {
        public TblProducts()
        {
            TblForeignCompany = new HashSet<TblForeignCompany>();
            TblTypicalSubcontractedScope = new HashSet<TblTypicalSubcontractedScope>();
        }

        public int ProductId { get; set; }
        public int? ProductCatId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblProductCategory ProductCat { get; set; }
        public virtual ICollection<TblForeignCompany> TblForeignCompany { get; set; }
        public virtual ICollection<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
    }
}
