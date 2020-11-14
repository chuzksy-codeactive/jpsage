using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.JustificationOfAward
{
    public class SingleTenderJustificationFormModel
    {
        [MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string ContactName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string TelephoneNumber { get; set; }
        public int? ProjectId { get; set; }
        public string ProposedContract { get; set; }
        public decimal? ProposedContractValue { get; set; }
        [MaxLength(200)]
        public string ProposedContractor { get; set; }
        public string Justification { get; set; }   
        public IFormFile AdditionalInfo { get; set; }
    }
}
