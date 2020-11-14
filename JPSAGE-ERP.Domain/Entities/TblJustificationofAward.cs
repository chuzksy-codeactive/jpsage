using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblJustificationofAward
    {
        public int Joaid { get; set; }
        public int? ProjectId { get; set; }
        public string Rqnnumber { get; set; }
        public int? Rfqid { get; set; }
        public int? SupplierId { get; set; }
        public decimal? ScoreTechnicalEval { get; set; }
        public decimal? VendorBidPrice { get; set; }
        public decimal? ScoreCommercialEval { get; set; }
        public string EndUser { get; set; }
        public int? EndUserDepartmentId { get; set; }
        public DateTime? Date { get; set; }
        public string JustificationofAward { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblDepartments EndUserDepartment { get; set; }
        public virtual TblProjects Project { get; set; }
        public virtual TblQuotationMaster Rfq { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
