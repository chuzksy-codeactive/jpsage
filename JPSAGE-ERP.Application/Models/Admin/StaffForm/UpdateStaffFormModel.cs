using Microsoft.AspNetCore.Http;

namespace JPSAGE_ERP.Application.Models.Admin.StaffForm
{
    public class UpdateStaffFormModel
    {
        public string StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string TelephoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string PersonalEmailAddress { get; set; }
        public IFormFile ProfileImage { get; set; }

    }
}
