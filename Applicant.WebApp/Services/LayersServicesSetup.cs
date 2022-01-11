using Applicant.Application;
using Applicant.WebApp.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Applicant.WebApp.Services
{
    public class LayersServicesSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterApplicationLayer(configuration);
        }
    }
}
