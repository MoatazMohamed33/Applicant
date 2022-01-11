using Microsoft.AspNetCore.Builder;

namespace Applicant.WebApp.Factory
{
    public interface IApplicationSetup
    {
        void SetupApplication(IApplicationBuilder app);
    }
}
