using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblProjects
    {
        public TblProjects()
        {
            TblEndUserRequisitionProducts = new HashSet<TblEndUserRequisitionProducts>();
            TblEndUserRequisitionServices = new HashSet<TblEndUserRequisitionServices>();
            TblJustificationofAward = new HashSet<TblJustificationofAward>();
            TblMtoforms = new HashSet<TblMtoforms>();
            TblPurchaseOrder = new HashSet<TblPurchaseOrder>();
            TblQuotationMaster = new HashSet<TblQuotationMaster>();
            TblSingleTenderJustification = new HashSet<TblSingleTenderJustification>();
            TblSrdailyReporting = new HashSet<TblSrdailyReporting>();
            TblSrdailyReportingTemp = new HashSet<TblSrdailyReportingTemp>();
            TblSrnonConformanceReports = new HashSet<TblSrnonConformanceReports>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual ICollection<TblEndUserRequisitionServices> TblEndUserRequisitionServices { get; set; }
        public virtual ICollection<TblJustificationofAward> TblJustificationofAward { get; set; }
        public virtual ICollection<TblMtoforms> TblMtoforms { get; set; }
        public virtual ICollection<TblPurchaseOrder> TblPurchaseOrder { get; set; }
        public virtual ICollection<TblQuotationMaster> TblQuotationMaster { get; set; }
        public virtual ICollection<TblSingleTenderJustification> TblSingleTenderJustification { get; set; }
        public virtual ICollection<TblSrdailyReporting> TblSrdailyReporting { get; set; }
        public virtual ICollection<TblSrdailyReportingTemp> TblSrdailyReportingTemp { get; set; }
        public virtual ICollection<TblSrnonConformanceReports> TblSrnonConformanceReports { get; set; }
    }
}
