using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.Client
{
    public class UpdateClientFormModel
    {
        [MaxLength(200)]
        public string ClientName { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public IFormFile ClientLogo { get; set; }
    }
}
