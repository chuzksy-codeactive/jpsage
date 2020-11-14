using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Project
{
    public class CreateProjectFormModel
    {
        [MaxLength(20)]
        public string ProjectName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
