using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblStaffStrengthComp
    {
        public TblStaffStrengthComp()
        {
            TblNumberOfEmployees = new HashSet<TblNumberOfEmployees>();
        }

        public int StaffStrCompId { get; set; }
        public int SupplierId { get; set; }
        public string StaffPolicy { get; set; }
        public string Audit3rdParty { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
        public virtual ICollection<TblNumberOfEmployees> TblNumberOfEmployees { get; set; }
    }
}
