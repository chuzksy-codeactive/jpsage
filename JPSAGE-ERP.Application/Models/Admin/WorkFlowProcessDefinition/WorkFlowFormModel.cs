using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.WorkFlowProcessDefinition
{
    public class WorkFlowFormModel
    {
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        
    }
}
