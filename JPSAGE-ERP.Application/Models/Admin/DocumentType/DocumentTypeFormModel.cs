using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.DocumentType
{
    public class DocumentTypeFormModel
    {
        [MaxLength(20)]
        public string DocTypeName { get; set; }
        [MaxLength(500)]
        public string DocTypeDescription { get; set; }

    }
}
