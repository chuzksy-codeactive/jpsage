using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class PefUser
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid UserId { get; set; }
        public Guid? UnitId { get; set; }
        public Guid? OfficeId { get; set; }

        public virtual PefOffice Office { get; set; }
        public virtual DepartmentUnit Unit { get; set; }
        public virtual DafmisUser User { get; set; }
    }
}
