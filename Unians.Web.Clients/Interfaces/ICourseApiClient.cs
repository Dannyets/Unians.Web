using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.Course.Api.Data.Models;

namespace Unians.Web.Clients.Interfaces
{
    public interface ICourseApiClient
    {
        Task<List<ApiCourse>> GetCoursesForFaculty(int facultyId);

        Task<ApiCourse> GetCourse(int courseId);
    }
}
