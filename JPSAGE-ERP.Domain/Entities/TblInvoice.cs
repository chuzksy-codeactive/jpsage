using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblInvoice
    {
        public TblInvoice()
        {
            TblInvoiceDetails = new HashSet<TblInvoiceDetails>();
            TblInvoiceOtherInfo = new HashSet<TblInvoiceOtherInfo>();
        }

        public int InvoiceId { get; set; }
        public int? ClientId { get; set; }
        public int? CompanyInfoId { get; set; }
        public string IssuedBy { get; set; }
        public string Attention { get; set; }
        public string Contact { get; set; }
        public int? SupplierId { get; set; }
        public int? PoId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaxIdnumber { get; set; }
        public string VatregNumber { get; set; }
        public decimal? Vatrate { get; set; }
        public string ContractTitle { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblCompanyInfo CompanyInfo { get; set; }
        public virtual TblPurchaseOrder Po { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblInvoiceDetails> TblInvoiceDetails { get; set; }
        public virtual ICollection<TblInvoiceOtherInfo> TblInvoiceOtherInfo { get; set; }
    }
}
