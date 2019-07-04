using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unians.University.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Clients
{
    public class UniversityApiClient : BaseHttpClient, IUniversityApiClient
    {
        public UniversityApiClient(IConfiguration configuration, 
                                   HttpClient client) : base("University", configuration, client)
        {
        }

        public async Task<List<ApiUniversity>> GetUniversitiesAsync()
        {
            var route = "api/University/Get";

            return await Get<List<ApiUniversity>>(route);
        }

        public Task<List<ApiUniversity>> GetUniversitiesByIdsAsync(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiUniversity> GetUniversityByIdAsync(int id)
        {
            var route = $"api/University/Get/{id}";

            return await Get<ApiUniversity>(route);
        }
    }
}
