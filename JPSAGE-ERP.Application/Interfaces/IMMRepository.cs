using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Interfaces
{
    public interface IMMRepository
    {
        Task<string> RegisterJCCFormCheckerStatus(int JCCID, int? checkerStatus);
        Task<string> RegisterJCCFormAuthorizerStatus(int JCCID, int? authorizerStatus);
    }
}
