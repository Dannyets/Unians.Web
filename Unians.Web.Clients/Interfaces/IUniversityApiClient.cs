using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.University.Api.Data.Models;

namespace Unians.Web.Clients.Interfaces
{
    public interface IUniversityApiClient
    {
        Task<List<ApiUniversity>> GetUniversitiesAsync();

        Task<List<ApiUniversity>> GetUniversitiesByIdsAsync(List<int> ids);

        Task<ApiUniversity> GetUniversityByIdAsync(int id);
    }
}
