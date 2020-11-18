using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class Department
    {
        public Department()
        {
            DepartmentUnit = new HashSet<DepartmentUnit>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DepartmentUnit> DepartmentUnit { get; set; }
    }
}
