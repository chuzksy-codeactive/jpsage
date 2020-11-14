using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblDepartments
    {
        public TblDepartments()
        {
            TblEndUserRequisitionProducts = new HashSet<TblEndUserRequisitionProducts>();
            TblJustificationofAward = new HashSet<TblJustificationofAward>();
            TblNotificationGroup = new HashSet<TblNotificationGroup>();
            TblNumberOfEmployees = new HashSet<TblNumberOfEmployees>();
            TblPaymentRequestMaster = new HashSet<TblPaymentRequestMaster>();
            TblPosition = new HashSet<TblPosition>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? CompanyId { get; set; }
        public string DepartmentEmailAddress { get; set; }

        public virtual TblCompanyInfo Company { get; set; }
        public virtual ICollection<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual ICollection<TblJustificationofAward> TblJustificationofAward { get; set; }
        public virtual ICollection<TblNotificationGroup> TblNotificationGroup { get; set; }
        public virtual ICollection<TblNumberOfEmployees> TblNumberOfEmployees { get; set; }
        public virtual ICollection<TblPaymentRequestMaster> TblPaymentRequestMaster { get; set; }
        public virtual ICollection<TblPosition> TblPosition { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
    }
}
