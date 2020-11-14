using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPurchaseOrderMilestones
    {
        public int MilestoneId { get; set; }
        public int? PoId { get; set; }
        public string MilestoneDetails { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public decimal? MilestoneAmount { get; set; }
        public int? MilestoneDurationType { get; set; }
        public decimal? MilestoneWeight { get; set; }
        public string Vendor { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblPurchaseOrder Po { get; set; }
    }
}
