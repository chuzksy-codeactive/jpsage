using JPSAGE_ERP.Application.Helpers;
using JPSAGE_ERP.Application.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace JPSAGE_ERP.Application.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<SendEmailResponseDTO> SendEmailAsync(string userEmail, string emailSubject, string message)
        {
            var apiKey = Configuration["SendGridKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("JPSAGE@gmail.com", "JPSAGE.COM");
            var subject = emailSubject;
            var to = new EmailAddress(userEmail, "Test");
            var plainTextContent = message;
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

            return new SendEmailResponseDTO
            {
                ErrorMsg = response.ToString()
            };
        }
    }
}
