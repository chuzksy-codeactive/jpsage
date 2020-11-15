using FluentValidation;
using FluentValidation.AspNetCore;
using JPSAGE_ERP.Application.Interfaces;
using JPSAGE_ERP.Application.Models.SiteReporting;
using JPSAGE_ERP.Application.Repository;
using JPSAGE_ERP.Application.Services;
using JPSAGE_ERP.Application.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace JPSAGE_ERP.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IContractAwardRepository, ContractAwardRepository>();
            services.AddScoped<IEmailAddressRepository, EmailAddressRepository>();
            services.AddScoped<IEurRepository, EurRepository>();
            services.AddScoped<IMMRepository, MMRepository>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IUploadFileToBlob, UploadFileToBlob>();

            // DI for FluentValidator
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<DailyReportFormDTO>, DailyReportFormDTOValidator>();
        }
    }
}
