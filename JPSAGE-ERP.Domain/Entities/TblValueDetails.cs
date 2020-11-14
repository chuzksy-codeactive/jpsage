using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblValueDetails
    {
        public TblValueDetails()
        {
            TblMainCustomers = new HashSet<TblMainCustomers>();
        }

        public int ValueId { get; set; }
        public int ValueYear { get; set; }
        public string Value { get; set; }

        public virtual ICollection<TblMainCustomers> TblMainCustomers { get; set; }
    }
}
