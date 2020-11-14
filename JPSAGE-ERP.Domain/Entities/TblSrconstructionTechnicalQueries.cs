using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblSrconstructionTechnicalQueries
    {
        public TblSrconstructionTechnicalQueries()
        {
            TblSrfileAttachments = new HashSet<TblSrfileAttachments>();
        }

        public int Ctqid { get; set; }
        public string Ctqtitle { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string Ctqnumber { get; set; }
        public int? StaffId { get; set; }
        public DateTime? QueryDate { get; set; }
        public string Ctqdescription { get; set; }
        public string Attention { get; set; }
        public DateTime? ReplyRequiredDate { get; set; }
        public int? Priority { get; set; }
        public int? Srfaid { get; set; }
        public DateTime? QueryCloseDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual TblCity City { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblStaffBioData Staff { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblSrfileAttachments> TblSrfileAttachments { get; set; }
    }
}
