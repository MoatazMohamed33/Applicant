using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.WebApp.Factory
{
    public interface IServiceSetup
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
