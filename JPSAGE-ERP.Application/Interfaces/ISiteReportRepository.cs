using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Domain.Entities;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface ISiteReportRepository : IRepository<TblStaffBioData>
    {
        Task<(string checker, string authorizer)> GetWorkflowApprovers(int wfdefId);

        Task<PagedList<TblDepartments>> GetDepartments(ResourceParameters parameters);
    }
}
