using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblNotificationGroup
    {
        public int NoGrId { get; set; }
        public int? WfdefId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual TblDepartments Department { get; set; }
        public virtual TblPosition Position { get; set; }
        public virtual TblWorkflowProcessDef Wfdef { get; set; }
    }
}
