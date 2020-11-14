using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.DataObjects.Admin.Department
{
    public class UpdateDepartmentFormModel
    {
        [MaxLength(10)]
        public string DepartmentCode { get; set; }
        [MaxLength(200)]
        public string DepartmentName { get; set; }

    }
}
