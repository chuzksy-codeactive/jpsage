using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JPSAGE_ERP.Application.Models.Admin.Client
{
    public class CreateClientFormModel
    {
        [MaxLength(200)]
        public string ClientName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public IFormFile ClientLogo { get; set; }
    }
}
