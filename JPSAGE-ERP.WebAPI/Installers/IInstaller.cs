using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JPSAGE_ERP.WebAPI.Installers
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration configuration);

    }
}
