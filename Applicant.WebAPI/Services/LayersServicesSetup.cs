using Applicant.Application;
using Applicant.WebAPI.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.WebAPI.Services
{
    public class LayersServicesSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterApplicationLayer(configuration);
        }
    }
}
