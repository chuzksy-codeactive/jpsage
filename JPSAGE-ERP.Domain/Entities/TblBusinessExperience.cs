using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblBusinessExperience
    {
        public int BizExId { get; set; }
        public int? SupplierId { get; set; }
        public int? FinancialTurnover { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CompanyWorkedWith { get; set; }
        public string TimeFrame { get; set; }
        public string TransactionReference { get; set; }
        public string ScopeCovered { get; set; }
        public string HasContinuityPolicy { get; set; }
        public string ContinuityPolicy { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
