using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPaymentRequestDetails
    {
        public int PayReqDetId { get; set; }
        public int PayReqMasterId { get; set; }
        public string Description { get; set; }
        public string GlaccountCode { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalAmount { get; set; }
        public string AmountInWords { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblPaymentRequestMaster PayReqMaster { get; set; }
    }
}
