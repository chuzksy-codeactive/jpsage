using System;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.InvoiceForPayment
{
    public class CreateInvoiceFormModel
    {
        public int? ClientId { get; set; }
        public int? CompanyInfoId { get; set; }
        [MaxLength(200)]
        public string IssuedBy { get; set; }
        [MaxLength(200)]
        public string Attention { get; set; }
        [MaxLength(200)]
        public string Contact { get; set; }
        public int? SupplierId { get; set; }
        public int? PoId { get; set; }
        [MaxLength(100)]
        public string InvoiceNumber { get; set; }
        public DateTime? DueDate { get; set; }
        [MaxLength(100)]
        public string TaxIdnumber { get; set; }
        [MaxLength(100)]
        public string VatregNumber { get; set; }
        public decimal? Vatrate { get; set; }
        [MaxLength(500)]
        public string ContractTitle { get; set; }
        public int? Status { get; set; }
        [MaxLength(500)]
        public string StatusReason { get; set; }
    }
}
