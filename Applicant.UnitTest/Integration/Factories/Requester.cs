using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Applicant.UnitTest.Integration.Factories
{
    public class Requester
    {
        protected readonly HttpClient TestClient;

        public Requester(HttpClient httpClient)
        {
            TestClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await TestClient.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }

    }
}