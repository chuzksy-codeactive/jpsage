using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSingleTenderJustification
    {
        public int Stjid { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public int? ProjectId { get; set; }
        public string ProposedContract { get; set; }
        public decimal? ProposedContractValue { get; set; }
        public string ProposedContractor { get; set; }
        public string Justification { get; set; }
        public string AdditionalInfo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? SupplierId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblProjects Project { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
