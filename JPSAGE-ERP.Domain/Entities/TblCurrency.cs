using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCurrency
    {
        public TblCurrency()
        {
            TblPurchaseOrderDetails = new HashSet<TblPurchaseOrderDetails>();
        }

        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }

        public virtual ICollection<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
    }
}
