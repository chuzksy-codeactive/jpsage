using JPSAGE_ERP.Application.Models;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Services
{
    public interface IEmailSender
    {
        Task<SendEmailResponseDTO> SendEmailAsync(string userEmail, string emailSubject, string message);
    }
}
