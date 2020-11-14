using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.StaffForm
{
    public class CreateStaffFormModel
    {
        [Required]
        public string StaffNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = " First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = " Last Name")]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = " Telephone Number")]
        public string TelephoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string PersonalEmailAddress { get; set; }
        [EmailAddress]
        public string OfficeEmailAddress { get; set; }
        public IFormFile ProfileImage { get; set; }
       

    }
}
