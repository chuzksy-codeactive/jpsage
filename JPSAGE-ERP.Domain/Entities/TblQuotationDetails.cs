using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblQuotationDetails
    {
        public int QuoDetId { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public int? Unit { get; set; }
        public decimal? EstimatedCost { get; set; }
        public string DetailedSpec { get; set; }
        public string TermsCondition { get; set; }
        public int QuoMasterId { get; set; }
        public string QuoteRef { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblQuotationMaster QuoMaster { get; set; }
    }
}
