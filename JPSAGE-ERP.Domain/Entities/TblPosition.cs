using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblPosition
    {
        public TblPosition()
        {
            TblEndUserRequisitionProducts = new HashSet<TblEndUserRequisitionProducts>();
            TblNotificationGroup = new HashSet<TblNotificationGroup>();
            TblStaffBioData = new HashSet<TblStaffBioData>();
        }

        public int PositionId { get; set; }
        public string PositionCode { get; set; }
        public string PositionTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? DepartmentId { get; set; }
        public string PositionEmailAddress { get; set; }

        public virtual TblDepartments Department { get; set; }
        public virtual ICollection<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual ICollection<TblNotificationGroup> TblNotificationGroup { get; set; }
        public virtual ICollection<TblStaffBioData> TblStaffBioData { get; set; }
    }
}
