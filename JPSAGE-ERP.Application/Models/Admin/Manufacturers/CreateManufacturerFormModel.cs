using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Manufacturers
{
    public class CreateManufacturerFormModel
    {
        [MaxLength(100)]
        public string ManufacturerName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
