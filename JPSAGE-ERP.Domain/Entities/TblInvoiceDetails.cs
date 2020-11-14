using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblInvoiceDetails
    {
        public int InvoiceDetId { get; set; }
        public int? InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal? Amount { get; set; }
        public string AmountInWords { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblInvoice Invoice { get; set; }
    }
}
