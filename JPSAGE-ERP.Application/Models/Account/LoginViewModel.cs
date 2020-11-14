using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
