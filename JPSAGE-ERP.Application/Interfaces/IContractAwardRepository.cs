using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface IContractAwardRepository
    {
        Task<string> RegisterCAFormCheckerStatus(int PoId, int? checkerStatus);
        Task<string> RegisterCAFormAuthorizerStatus(int PoId, int? authorizerStatus);
    }
}
