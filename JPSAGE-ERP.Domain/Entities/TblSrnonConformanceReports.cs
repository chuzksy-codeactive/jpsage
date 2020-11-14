using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrnonConformanceReports
    {
        public TblSrnonConformanceReports()
        {
            TblSrfileAttachments = new HashSet<TblSrfileAttachments>();
        }

        public int Ncrid { get; set; }
        public string Title { get; set; }
        public string ReportNumber { get; set; }
        public int? ProjectId { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string AreaModuleNumber { get; set; }
        public string DrawingReferenceNumber { get; set; }
        public string TagNumber { get; set; }
        public string Item { get; set; }
        public string SystemsSubSystems { get; set; }
        public int? SupplierId { get; set; }
        public bool? ReqEngApproval { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public string ContractorProposedDisposition { get; set; }
        public int? Disposition { get; set; }
        public string DispositionSubmittedBy { get; set; }
        public DateTime? DispositionSubmittedDate { get; set; }
        public int? AgreedDueDate { get; set; }
        public int? DispositionResponse { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblState State { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblSrfileAttachments> TblSrfileAttachments { get; set; }
    }
}
