using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.WebAPI.Factory
{
    public interface IServiceSetup
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
