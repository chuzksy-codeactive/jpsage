using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblMtoforms
    {
        public TblMtoforms()
        {
            TblEndUserRequisitionProductsMto = new HashSet<TblEndUserRequisitionProductsMto>();
            TblEndUserRequisitionServicesMto = new HashSet<TblEndUserRequisitionServicesMto>();
            TblMtoformDetails = new HashSet<TblMtoformDetails>();
        }

        public int MtoformId { get; set; }
        public int ProjectId { get; set; }
        public string FormName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ValidityPeriod { get; set; }
        public int? ValidityStatus { get; set; }
        public int? CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int? Discipline { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblClients Client { get; set; }
        public virtual TblCompanyInfo Company { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual ICollection<TblEndUserRequisitionProductsMto> TblEndUserRequisitionProductsMto { get; set; }
        public virtual ICollection<TblEndUserRequisitionServicesMto> TblEndUserRequisitionServicesMto { get; set; }
        public virtual ICollection<TblMtoformDetails> TblMtoformDetails { get; set; }
    }
}
