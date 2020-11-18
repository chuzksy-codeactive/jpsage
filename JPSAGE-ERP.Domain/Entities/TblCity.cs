using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblCyMfgFf = new HashSet<TblCyMfgFf>();
            TblEndUserRequisitionServices = new HashSet<TblEndUserRequisitionServices>();
            TblMtoformDetails = new HashSet<TblMtoformDetails>();
            TblOfficeServiceCl = new HashSet<TblOfficeServiceCl>();
            TblSrconstructionTechnicalQueries = new HashSet<TblSrconstructionTechnicalQueries>();
            TblSrconstructionTechnicalQueriesTemp = new HashSet<TblSrconstructionTechnicalQueriesTemp>();
            TblSrnonConformanceReports = new HashSet<TblSrnonConformanceReports>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
        }

        public int CityId { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<TblCyMfgFf> TblCyMfgFf { get; set; }
        public virtual ICollection<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual ICollection<TblMtoformDetails> TblMtoformDetails { get; set; }
        public virtual ICollection<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueries { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTemp { get; set; }
        public virtual ICollection<TblSrnonConformanceReports> TblSrnonConformanceReports { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
    }
}
