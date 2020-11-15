using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class Account
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Cac { get; set; }
        public string Nin { get; set; }
        public int AccountType { get; set; }
        public int Status { get; set; }
        public Guid UserId { get; set; }

        public virtual DafmisUser User { get; set; }
    }
}
