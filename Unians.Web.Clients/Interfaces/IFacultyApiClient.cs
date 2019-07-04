using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.Faculty.Api.Data.Models;

namespace Unians.Web.Clients.Interfaces
{
    public interface IFacultyApiClient
    {
        Task<List<ApiFaculty>> GetFacultiesForUniversity(int universityId);

        Task<ApiFaculty> GetFaculty(int id);
    }
}
