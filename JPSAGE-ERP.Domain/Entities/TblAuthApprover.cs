using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblAuthApprover
    {
        public int AuthAppId { get; set; }
        public int? StaffId { get; set; }
        public string Reason { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Status { get; set; }
        public int? AuthId { get; set; }
        public bool? IsApproved { get; set; }

        public virtual TblAuthList Auth { get; set; }
        public virtual TblStaffBioData Staff { get; set; }
    }
}
