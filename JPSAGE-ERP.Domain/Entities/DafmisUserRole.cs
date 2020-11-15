using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class DafmisUserRole
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
