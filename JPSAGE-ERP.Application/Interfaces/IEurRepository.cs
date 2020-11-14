using JPSAGE_ERP.Domain.Entities;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface IEurRepository : IRepository<TblPaymentRequestMaster>
    {
        Task<string> RegisterEurFormCheckerStatus(int eurformId, int? checkerStatus);
        Task<string> RegisterEurFormAuthorizerStatus(int eurformId, int? authorizerStatus);
        Task<TblPaymentRequestDetails> GetCorrespondingDetails(int id);
    }
}
