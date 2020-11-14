using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblTenderAttachements
    {
        public TblTenderAttachements()
        {
            TblQuotationMaster = new HashSet<TblQuotationMaster>();
        }

        public int TenderAttId { get; set; }
        public int? DocTypeId { get; set; }
        public string DocumentTitle { get; set; }
        public string DocumentUrl { get; set; }
        public int? FileSize { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? QuoMasterId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblDocumentType DocType { get; set; }
        public virtual TblQuotationMaster QuoMaster { get; set; }
        public virtual ICollection<TblQuotationMaster> TblQuotationMaster { get; set; }
    }
}
