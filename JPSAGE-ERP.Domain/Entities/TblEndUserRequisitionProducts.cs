using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionProducts
    {
        public TblEndUserRequisitionProducts()
        {
            TblEndUserRequisitionProductsDeliveryInfo = new HashSet<TblEndUserRequisitionProductsDeliveryInfo>();
            TblEndUserRequisitionProductsDetails = new HashSet<TblEndUserRequisitionProductsDetails>();
            TblEndUserRequisitionProductsMto = new HashSet<TblEndUserRequisitionProductsMto>();
            TblEndUserRequisitionProductsOtherInfo = new HashSet<TblEndUserRequisitionProductsOtherInfo>();
        }

        public int Eurpid { get; set; }
        public int? StaffId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public int? ProjectId { get; set; }
        public int? ClientId { get; set; }
        public string RequestTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? BudgetEstimate { get; set; }
        public decimal? TechnicalScore { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblDepartments Department { get; set; }
        public virtual TblPosition Position { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblStaffBioData Staff { get; set; }
        public virtual ICollection<TblEndUserRequisitionProductsDeliveryInfo> TblEndUserRequisitionProductsDeliveryInfo { get; set; }
        public virtual ICollection<TblEndUserRequisitionProductsDetails> TblEndUserRequisitionProductsDetails { get; set; }
        public virtual ICollection<TblEndUserRequisitionProductsMto> TblEndUserRequisitionProductsMto { get; set; }
        public virtual ICollection<TblEndUserRequisitionProductsOtherInfo> TblEndUserRequisitionProductsOtherInfo { get; set; }
    }
}
