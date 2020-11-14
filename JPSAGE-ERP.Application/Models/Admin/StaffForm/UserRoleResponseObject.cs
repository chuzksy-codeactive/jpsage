using JPSAGE_ERP.Domain.Entities;
using System.Collections.Generic;

namespace JPSAGE_ERP.Application.Models.Admin.StaffForm
{
    public class UserRoleResponseObject
    {
        public TblStaffBioData Staff { get; set; }
        public IList<string> Roles { get; set; }
    }
}
