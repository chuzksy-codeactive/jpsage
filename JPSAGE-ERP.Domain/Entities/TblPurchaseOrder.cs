using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPurchaseOrder
    {
        public TblPurchaseOrder()
        {
            TblInvoice = new HashSet<TblInvoice>();
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
            TblPurchaseOrderDetails = new HashSet<TblPurchaseOrderDetails>();
            TblPurchaseOrderMilestones = new HashSet<TblPurchaseOrderMilestones>();
        }

        public int PoId { get; set; }
        public int SupplierId { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string QuoteRef { get; set; }
        public int? Potype { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? Poamount { get; set; }
        public int? QuoMasterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int? CompanyId { get; set; }

        public virtual TblCompanyInfo Company { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblQuotationMaster QuoMaster { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblInvoice> TblInvoice { get; set; }
        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
        public virtual ICollection<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual ICollection<TblPurchaseOrderMilestones> TblPurchaseOrderMilestones { get; set; }
    }
}
