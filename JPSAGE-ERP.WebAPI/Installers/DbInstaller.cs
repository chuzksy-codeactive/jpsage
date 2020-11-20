using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SqlServer;
using JPSAGE_ERP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

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

            //services.AddHangfire(x => x.UseSqlServerStorage(configuration["DefaultConnection"]));
            services.AddHangfire(x => x.UseMemoryStorage());
            services.AddHangfireServer();
        }
    }
}
