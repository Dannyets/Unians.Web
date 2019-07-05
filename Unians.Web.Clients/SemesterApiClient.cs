using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unians.Semester.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Clients
{
    public class SemesterApiClient : BaseHttpClient, ISemesterApiClient
    {
        public SemesterApiClient(IConfiguration configuration, 
                                 HttpClient client) : base("Semester", configuration, client)
        {
        }

        public async Task<ApiSemester> GetSemester(int id)
        {
            var route = $"api/Semester/Get/{id}";

            return await Get<ApiSemester>(route);
        }

        public async Task<List<ApiSemester>> GetSemestersForUniversity(int universityId)
        {
            var route = "api/Semester/GetSemestersForUniversity";

            var queryString = $"universityId={universityId}";
            
            return await Get<List<ApiSemester>>(route, queryString);
        }
    }
}
