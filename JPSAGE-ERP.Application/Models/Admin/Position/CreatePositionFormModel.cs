using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Position
{
    public class CreatePositionFormModel
    {
        [Required]
        [MaxLength(10)]
        public string PositionCode { get; set; }
        [Required]
        [MaxLength(200)]
        public string PositionTitle { get; set; }
        public int Status { get; set; }
    }
}
