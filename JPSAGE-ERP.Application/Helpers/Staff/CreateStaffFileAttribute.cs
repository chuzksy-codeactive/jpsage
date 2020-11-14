using JPSAGE_ERP.Application.Models.Admin.StaffForm;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Helpers.Staff
{
    public class CreateStaffFileAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
       "File Size must be less than 2MB";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (CreateStaffFormModel)validationContext.ObjectInstance;

            if (model.ProfileImage.Length > 2097152)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
