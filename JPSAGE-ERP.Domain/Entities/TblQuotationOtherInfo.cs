using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQuotationOtherInfo
    {
        public TblQuotationOtherInfo()
        {
            TblQuotationOtherInfoAttachments = new HashSet<TblQuotationOtherInfoAttachments>();
        }

        public int OtherInfoId { get; set; }
        public bool SparesRequired { get; set; }
        public string AsservicesRq { get; set; }
        public int QuoMasterId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblQuotationMaster QuoMaster { get; set; }
        public virtual ICollection<TblQuotationOtherInfoAttachments> TblQuotationOtherInfoAttachments { get; set; }
    }
}
