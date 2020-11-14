using System;
using Microsoft.AspNetCore.Identity;

namespace JPSAGE_ERP.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        public int UserType { get; set; }
        public string LinkedIn { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public int? Rating { get; set; }
        public string Review { get; set; }
        public int? JobsCompleted { get; set; }
        public int? OnTime { get; set; }
        public int? OnBudget { get; set; }
        public int? RepeatHireRate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
