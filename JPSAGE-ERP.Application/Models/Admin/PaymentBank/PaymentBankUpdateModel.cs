using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.Admin.PaymentBank
{
    public class PaymentBankUpdateModel
    {
        [MaxLength(10)]
        public string PaymentBankCode { get; set; }
        [MaxLength(100)]
        public string PaymentBankName { get; set; }

    }
}
