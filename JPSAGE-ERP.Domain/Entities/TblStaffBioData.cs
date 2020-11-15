using System;
using System.Collections.Generic;

namespace JPSAGE_ERP.Domain.Entities
{
    public partial class TblStaffBioData
    {
        public TblStaffBioData()
        {
            TblAuthApprover = new HashSet<TblAuthApprover>();
            TblAuthChecker = new HashSet<TblAuthChecker>();
            TblEndUserRequisitionProducts = new HashSet<TblEndUserRequisitionProducts>();
            TblEventDetails = new HashSet<TblEventDetails>();
            TblSrconstructionTechnicalQueriesAttentionNavigation = new HashSet<TblSrconstructionTechnicalQueries>();
            TblSrconstructionTechnicalQueriesStaff = new HashSet<TblSrconstructionTechnicalQueries>();
            TblSrconstructionTechnicalQueriesTempAttentionNavigation = new HashSet<TblSrconstructionTechnicalQueriesTemp>();
            TblSrconstructionTechnicalQueriesTempStaff = new HashSet<TblSrconstructionTechnicalQueriesTemp>();
            TblStaffRoles = new HashSet<TblStaffRoles>();
        }

        public int StaffId { get; set; }
        public string StaffNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? DepartmentId { get; set; }
        public int? PositionId { get; set; }
        public string TelephoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string PersonalEmailAddress { get; set; }
        public string OfficeEmailAddress { get; set; }
        public string AspnetUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProfileImage { get; set; }
        public int? CompanyId { get; set; }

        public virtual AspNetUsers AspnetUser { get; set; }
        public virtual TblCity City { get; set; }
        public virtual TblCompanyInfo Company { get; set; }
        public virtual TblCountry Country { get; set; }
        public virtual TblDepartments Department { get; set; }
        public virtual TblPosition Position { get; set; }
        public virtual TblState State { get; set; }
        public virtual ICollection<TblAuthApprover> TblAuthApprover { get; set; }
        public virtual ICollection<TblAuthChecker> TblAuthChecker { get; set; }
        public virtual ICollection<TblEndUserRequisitionProducts> TblEndUserRequisitionProducts { get; set; }
        public virtual ICollection<TblEventDetails> TblEventDetails { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueriesAttentionNavigation { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueries> TblSrconstructionTechnicalQueriesStaff { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTempAttentionNavigation { get; set; }
        public virtual ICollection<TblSrconstructionTechnicalQueriesTemp> TblSrconstructionTechnicalQueriesTempStaff { get; set; }
        public virtual ICollection<TblStaffRoles> TblStaffRoles { get; set; }
    }
}
