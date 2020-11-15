using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblState
    {
        public TblState()
        {
            TblEndUserRequisitionServices = new HashSet<TblEndUserRequisitionServices>();
            TblMtoformDetails = new HashSet<TblMtoformDetails>();
            TblSrconstructionTechnicalQueries = new HashSet<TblSrconstructionTechnicalQueries>();
            TblSrconstructionTechnicalQueriesTemp = new HashSet<TblSrconstructionTechnicalQueriesTemp>();
            TblSrnonConformanceReports = new HashSet<TblSrnonConformanceReports>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
        }

        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual ICollection<TblMtoformDetails> TblMtoformDetails { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueries { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTemp { get; set; }
        public virtual ICollection<TblSrnonConformanceReports> TblSrnonConformanceReports { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
    }
}
