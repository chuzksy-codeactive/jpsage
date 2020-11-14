using JPSAGE_ERP.Application.Models.Admin.Client;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Helpers.Client
{
    public class ClientCreateFileAttribute : ValidationAttribute
    {
        public string GetErrorMessage() =>
       "File Size must be less than 2MB";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = (CreateClientFormModel)validationContext.ObjectInstance;

            if (model.ClientLogo.Length > 2097152)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
