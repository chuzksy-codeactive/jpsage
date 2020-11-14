using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Position
{
    public class UpdatePositionFormModel
    {
        [MaxLength(10)]
        public string PositionCode { get; set; }
        [MaxLength(200)]
        public string PositionTitle { get; set; }

    }
}
