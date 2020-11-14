using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblInvoiceOtherInfo
    {
        public int InvoiceOtherInfoId { get; set; }
        public int? InvoiceId { get; set; }
        public int? PaymentBankId { get; set; }
        public string AccountDetails { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string SortCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblInvoice Invoice { get; set; }
    }
}
