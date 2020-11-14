using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQuotationApproval
    {
        public int QuoAppId { get; set; }
        public string BuyerName { get; set; }
        public string ApprovalSignature { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int QuoMasterId { get; set; }

        public virtual TblQuotationMaster QuoMaster { get; set; }
    }
}
