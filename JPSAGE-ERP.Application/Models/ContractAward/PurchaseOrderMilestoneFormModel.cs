using System;

namespace JPSAGE_ERP.Application.Models.ContractAward
{
    public class PurchaseOrderMilestoneFormModel
    {
        public int? PoId { get; set; }
        public string MilestoneDetails { get; set; }
        public DateTime? EstimatedDate { get; set; }
        public decimal? MilestoneAmount { get; set; }
        public int? MilestoneDurationType { get; set; }
    }
}
