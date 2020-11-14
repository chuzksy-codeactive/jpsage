using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblFormIdentification
    {
        public TblFormIdentification()
        {
            TblContactPersons = new HashSet<TblContactPersons>();
            TblSupplierIdentification = new HashSet<TblSupplierIdentification>();
            TblThirdPartyReference = new HashSet<TblThirdPartyReference>();
        }

        public int FormId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string WorkPhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<TblContactPersons> TblContactPersons { get; set; }
        public virtual ICollection<TblSupplierIdentification> TblSupplierIdentification { get; set; }
        public virtual ICollection<TblThirdPartyReference> TblThirdPartyReference { get; set; }
    }
}
