using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.ApprovalWorkFlow
{
    public class AuthStatusModel
    {
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Url { get; set; }

        [MaxLength(1000)]
        public string Reason { get; set; }

        public int Status { get; set; }
        [Required]
        public string BatchId { get; set; }

    }
}
