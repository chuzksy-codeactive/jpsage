using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSubContractedDetails
    {
        public int SubConId { get; set; }
        public int SubServId { get; set; }
        public string SubConName { get; set; }
        public string SubConAddress { get; set; }
        public int? CountryId { get; set; }
        public bool? IsLocal { get; set; }

        public virtual TblCountry Country { get; set; }
        public virtual TblSubContractedServices SubServ { get; set; }
    }
}
