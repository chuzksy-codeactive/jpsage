using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class PefOffice
    {
        public PefOffice()
        {
            PefUser = new HashSet<PefUser>();
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
        public int Jurisdication { get; set; }
        public string Address { get; set; }
        public Guid? ZoneAreaId { get; set; }

        public virtual ZoneArea ZoneArea { get; set; }
        public virtual ICollection<PefUser> PefUser { get; set; }
    }
}
