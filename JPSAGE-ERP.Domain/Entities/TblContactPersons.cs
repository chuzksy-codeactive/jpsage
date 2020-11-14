using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblContactPersons
    {
        public TblContactPersons()
        {
            TblSupplierIdentification = new HashSet<TblSupplierIdentification>();
        }

        public int ContactPersonId { get; set; }
        public string ContactPersonName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? FormId { get; set; }

        public virtual TblFormIdentification Form { get; set; }
        public virtual ICollection<TblSupplierIdentification> TblSupplierIdentification { get; set; }
    }
}
