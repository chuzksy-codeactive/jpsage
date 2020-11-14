using System;
using System.ComponentModel.DataAnnotations;

namespace JPSAGE_ERP.Application.Models.MIlestoneManagement
{
    public class JobCompletionCertificateFormModel
    {
        [MaxLength(20)]
        public string CertificateNumber { get; set; }
        [MaxLength(50)]
        public string WorkOrder { get; set; }
        public int? SupplierId { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(200)]
        public string DeliveryAddress { get; set; }
        public string Telephone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public DateTime? RecieptDate { get; set; }
        public string ServiceDescription { get; set; }
    }
}
