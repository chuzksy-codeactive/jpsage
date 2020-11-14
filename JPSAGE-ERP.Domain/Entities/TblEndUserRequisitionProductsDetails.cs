using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionProductsDetails
    {
        public int EurpdetId { get; set; }
        public int? Eurpid { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public decimal? EstimatedCost { get; set; }
        public string DetailedSpec { get; set; }
        public string RefCodeStandards { get; set; }
        public string TermsCondition { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblEndUserRequisitionProducts Eurp { get; set; }
    }
}
