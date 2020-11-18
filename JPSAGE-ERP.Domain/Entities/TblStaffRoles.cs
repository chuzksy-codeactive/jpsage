using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblStaffRoles
    {
        public int StaffRoleId { get; set; }
        public int? WfdefId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CheckerId { get; set; }
        public int? AuthoriserId { get; set; }

        public virtual TblStaffBioData Authoriser { get; set; }
        public virtual TblStaffBioData Checker { get; set; }
        public virtual TblWorkflowProcessDef Wfdef { get; set; }
    }
}
