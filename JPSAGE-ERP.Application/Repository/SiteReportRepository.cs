using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Domain;
using JPSAGE_ERP.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Repository
{
    public class SiteReportRepository : Repository<TblStaffBioData>, ISiteReportRepository
    {
        public SiteReportRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public Task<PagedList<TblDepartments>> GetDepartments(ResourceParameters parameters)
        {
            var query = _context.TblDepartments as IQueryable<TblDepartments>;

            var departments = PagedList<TblDepartments>.Create(query, parameters.PageNumber, parameters.PageSize);

            return departments;
        }

        /// <summary>
        /// This method is to get the checker's and
        /// approver's email address
        /// </summary>
        /// <param name="wfdefId"></param>
        /// <returns></returns>
        public async Task<(string checker, string authorizer)> GetWorkflowApprovers(int wfdefId)
        {
            var staffRole = await _context.TblStaffRoles.FirstOrDefaultAsync(x => x.WfdefId == wfdefId);

            if (staffRole == null)
            {
                throw new ArgumentNullException(nameof(staffRole));
            }

            var checker = await _context.TblStaffBioData.FirstOrDefaultAsync(x => x.StaffId == staffRole.CheckerId);
            var approver = await _context.TblStaffBioData.FirstOrDefaultAsync(x => x.StaffId == staffRole.AuthoriserId);

            if (checker == null || approver == null) throw new ArgumentNullException(nameof(staffRole));

            return (checker.OfficeEmailAddress, approver.OfficeEmailAddress);
        }
    }
}
