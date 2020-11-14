using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSupplierProfile
    {
        public int SupplierProfileId { get; set; }
        public int SupplierId { get; set; }
        public string NatureOfBusiness { get; set; }
        public DateTime DateofCreation { get; set; }
        public string OrganizationCharts { get; set; }
        public string MissionVisionStatement { get; set; }
        public string CodeofConduct { get; set; }

        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
