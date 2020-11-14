using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using JPSAGE_ERP.Domain;

namespace JPSAGE_ERP.WebAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public static readonly ILoggerFactory ERPLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseLoggerFactory(ERPLoggerFactory)
                    .UseSqlServer(
                        configuration["DefaultConnection"]));
        }
    }
}
