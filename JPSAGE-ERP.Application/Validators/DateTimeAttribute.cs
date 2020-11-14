using JPSAGE_ERP.Application.Models.InvoiceForPayment;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Validators
{
    public class DateTimeAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => "Date range invalid ";
        protected override ValidationResult IsValid(object value,
           ValidationContext validationContext)
        {
            var model = (PaymentRequestFormModel)validationContext.ObjectInstance;
            if (model.PayReqDate != null && (model.PayReqDate.Year < 1753 || model.PayReqDate.Year > 9999))
            {
                return new ValidationResult(GetErrorMessage());
            }


            return ValidationResult.Success;
        }
    }
}
