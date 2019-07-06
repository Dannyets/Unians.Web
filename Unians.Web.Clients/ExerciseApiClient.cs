using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Unians.Exercise.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Clients
{
    public class ExerciseApiClient : BaseHttpClient, IExerciseApiClient
    {
        public ExerciseApiClient(IConfiguration configuration, 
                                 HttpClient client) : base("Exercise", configuration, client)
        {
        }

        public async Task<List<ApiExercise>> GetExercisesForCourseAndSemester(int courseId, int semesterId)
        {
            var route = "api/Exercise/GetExercisesForCourseAndSemester";

            var queryString = $"courseId={courseId}&semesterId={semesterId}";

            var exercises = await Get<List<ApiExercise>>(route, queryString);

            return exercises;
        }
    }
}
