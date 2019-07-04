using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unians.Faculty.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Clients
{
    public class FacultyApiClient : BaseHttpClient, IFacultyApiClient
    {
        public FacultyApiClient(IConfiguration configuration, 
                                HttpClient client) : base("Faculty", configuration, client)
        {
        }

        public async Task<ApiFaculty> GetFaculty(int id)
        {
            var route = $"api/Faculty/Get/{id}";

            return await Get<ApiFaculty>(route);
        }

        public async Task<List<ApiFaculty>> GetFacultiesForUniversity(int universityId)
        {
            var route = "api/Faculty/GetFacultiesForUniversity";

            var queryString = $"universityId={universityId}";

            return await Get<List<ApiFaculty>>(route, queryString);
        }
    }
}
