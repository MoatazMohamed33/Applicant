using Applicant.Application;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Applicant.Infrastructure.Integration
{
    public class CountryService : ICountryService
    {
        public async Task<bool> CheckCountry(string name, CancellationToken token)
        {
            var client = new RestClient($@"https://restcountries.com/v2/name/{name}?fullText=true");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                if (response.Content.Contains("404"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
