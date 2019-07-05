using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.Semester.Api.Data.Models;

namespace Unians.Web.Clients.Interfaces
{
    public interface ISemesterApiClient
    {
        Task<List<ApiSemester>> GetSemestersForUniversity(int universityId);

        Task<ApiSemester> GetSemester(int id);
    }
}
