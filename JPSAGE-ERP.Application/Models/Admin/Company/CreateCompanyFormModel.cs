using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Company
{
    public class CreateCompanyFormModel
    {
        [MaxLength(200)]
        public string CompanyName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        [Phone]
        [MaxLength(50)]
        public string PhoneNumber1 { get; set; }
        [Phone]
        [MaxLength(50)]
        public string PhoneNumber2 { get; set; }
        [EmailAddress]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [MaxLength(100)]
        public string WebsiteUrl { get; set; }
        public IFormFile CompanyLogo { get; set; }
    }
}
