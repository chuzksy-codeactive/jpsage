using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblOfficeServiceCl
    {
        public int OfficeServClId { get; set; }
        public string SpServices { get; set; }
        public string Location { get; set; }
        public int? CityId { get; set; }
        public int? CountryId { get; set; }
        public int? SupplierId { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblSupplierIdentification Supplier { get; set; }
    }
}
