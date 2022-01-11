using Microsoft.AspNetCore.Builder;

namespace Applicant.WebAPI.Factory
{
    public interface IApplicationSetup
    {
        void SetupApplication(IApplicationBuilder app);
    }
}
