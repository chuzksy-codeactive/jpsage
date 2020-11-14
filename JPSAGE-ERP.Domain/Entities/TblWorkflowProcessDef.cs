using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblWorkflowProcessDef
    {
        public TblWorkflowProcessDef()
        {
            TblNotificationGroup = new HashSet<TblNotificationGroup>();
            TblStaffRoles = new HashSet<TblStaffRoles>();
        }

        public int WfdefId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblNotificationGroup> TblNotificationGroup { get; set; }
        public virtual ICollection<TblStaffRoles> TblStaffRoles { get; set; }
    }
}
