using AspNetCore.ServiceRegistration.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Application
{
    public interface ICountryService : IScopedService
    {
        public Task<bool> CheckCountry(string name, CancellationToken token);
    }
}
