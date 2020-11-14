using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Department
{
    public class CreateDepartmentFormModel
    {
        [Required]
        [MaxLength(10)]
        public string DepartmentCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string DepartmentName { get; set; }

        public int Status { get; set; }

    }
}
