using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class DafmisUser
    {
        public DafmisUser()
        {
            Account = new HashSet<Account>();
            PartnerUser = new HashSet<PartnerUser>();
            PefUser = new HashSet<PefUser>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Unit { get; set; }
        public int Gender { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool Activated { get; set; }
        public bool IsDeleted { get; set; }
        public int UserType { get; set; }
        public Guid? UserTypeId { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<PartnerUser> PartnerUser { get; set; }
        public virtual ICollection<PefUser> PefUser { get; set; }
    }
}
