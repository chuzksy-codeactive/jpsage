using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblStaffRoles
    {
        public int StaffRoleId { get; set; }
        public int? WfdefId { get; set; }
        public int? StaffId { get; set; }
        public string Checker { get; set; }
        public string Authorizer { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblStaffBioData Staff { get; set; }
        public virtual TblWorkflowProcessDef Wfdef { get; set; }
    }
}
