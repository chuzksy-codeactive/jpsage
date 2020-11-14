using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQuotationMaster
    {
        public TblQuotationMaster()
        {
            TblJustificationofAward = new HashSet<TblJustificationofAward>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
            TblQuotationApproval = new HashSet<TblQuotationApproval>();
            TblQuotationDeliveryInfo = new HashSet<TblQuotationDeliveryInfo>();
            TblQuotationDetails = new HashSet<TblQuotationDetails>();
            TblQuotationOtherInfo = new HashSet<TblQuotationOtherInfo>();
            TblTenderAttachements = new HashSet<TblTenderAttachements>();
        }

        public int QuoMasterId { get; set; }
        public int SupplierId { get; set; }
        public int? ProjectId { get; set; }
        public string Rfqnumber { get; set; }
        public string RequestTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ClientId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? QuotationDate { get; set; }
        public bool? CanExtend { get; set; }
        public string ExtensionJustification { get; set; }
        public DateTime? ExtensionDate { get; set; }
        public DateTime? ExtensionReminder { get; set; }
        public int? TenderAttId { get; set; }
        public int? EventId { get; set; }
        public int? Rfqtype { get; set; }
        public DateTime? ExpiryReminderDate { get; set; }
        public bool? SubContractorNeeded { get; set; }
        public int? SubContractorType { get; set; }
        public bool? ProjectConsortiumNeeded { get; set; }
        public int? NoOfProjectConsortiums { get; set; }
        public int? NoOfSubContractors { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblEvents Event { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual TblTenderAttachements TenderAtt { get; set; }
        public virtual ICollection<TblJustificationofAward> TblJustificationofAward { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual ICollection<TblQuotationApproval> TblQuotationApproval { get; set; }
        public virtual ICollection<TblQuotationDeliveryInfo> TblQuotationDeliveryInfo { get; set; }
        public virtual ICollection<TblQuotationDetails> TblQuotationDetails { get; set; }
        public virtual ICollection<TblQuotationOtherInfo> TblQuotationOtherInfo { get; set; }
        public virtual ICollection<TblTenderAttachements> TblTenderAttachements { get; set; }
    }
}
