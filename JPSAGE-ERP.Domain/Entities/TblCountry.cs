using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblCountry
    {
        public TblCountry()
        {
            TblEndUserRequisitionServices = new HashSet<TblEndUserRequisitionServices>();
            TblMainCustomers = new HashSet<TblMainCustomers>();
            TblMtoformDetails = new HashSet<TblMtoformDetails>();
            TblOfficeServiceCl = new HashSet<TblOfficeServiceCl>();
            TblSrconstructionTechnicalQueries = new HashSet<TblSrconstructionTechnicalQueries>();
            TblSrconstructionTechnicalQueriesTemp = new HashSet<TblSrconstructionTechnicalQueriesTemp>();
            TblSrnonConformanceReports = new HashSet<TblSrnonConformanceReports>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
            TblSubContractedDetails = new HashSet<TblSubContractedDetails>();
            TblSupplierOwnership = new HashSet<TblSupplierOwnership>();
            TblTypicalSubcontractedScope = new HashSet<TblTypicalSubcontractedScope>();
        }

        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual ICollection<TblMainCustomers> TblMainCustomers { get; set; }
        public virtual ICollection<TblMtoformDetails> TblMtoformDetails { get; set; }
        public virtual ICollection<TblOfficeServiceCl> TblOfficeServiceCl { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueries { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTemp { get; set; }
        public virtual ICollection<TblSrnonConformanceReports> TblSrnonConformanceReports { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
        public virtual ICollection<TblSubContractedDetails> TblSubContractedDetails { get; set; }
        public virtual ICollection<TblSupplierOwnership> TblSupplierOwnership { get; set; }
        public virtual ICollection<TblTypicalSubcontractedScope> TblTypicalSubcontractedScope { get; set; }
    }
}
