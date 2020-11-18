using JPSAGE_ERP.Domain.Entities;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface ISiteReportRepository : IRepository<TblStaffBioData>
    {
        Task<(string checker, string authorizer)> GetWorkflowApprovers(int wfdefId);
    }
}
