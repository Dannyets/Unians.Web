using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unians.Course.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Clients
{
    public class CourseApiClient : BaseHttpClient, ICourseApiClient
    {
        public CourseApiClient(IConfiguration configuration, HttpClient client) : base("Course", configuration, client)
        {
        }

        public async Task<ApiCourse> GetCourse(int courseId)
        {
            var route = $"api/Course/Get/{courseId}";

            var course = await Get<ApiCourse>(route);

            return course;
        }

        public async Task<List<ApiCourse>> GetCoursesForFaculty(int facultyId)
        {
            var route = "api/Course/GetCoursesForFaculty";

            var queryString = $"facultyId={facultyId}";

            var courses = await Get<List<ApiCourse>>(route, queryString);

            return courses;
        }
    }
}
