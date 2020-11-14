using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblEndUserRequisitionServices
    {
        public TblEndUserRequisitionServices()
        {
            TblEndUserRequisitionServicesMto = new HashSet<TblEndUserRequisitionServicesMto>();
        }

        public int Eursid { get; set; }
        public string RequisitionNumber { get; set; }
        public string DocumentTitle { get; set; }
        public int? ProjectId { get; set; }
        public int? ClientId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? BudgetEstimate { get; set; }
        public decimal? TechnicalScore { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblClients Client { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblEndUserRequisitionServicesMto> TblEndUserRequisitionServicesMto { get; set; }
    }
}
