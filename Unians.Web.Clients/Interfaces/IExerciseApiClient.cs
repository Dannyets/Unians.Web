using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unians.Exercise.Api.Data.Models;

namespace Unians.Web.Clients.Interfaces
{
    public interface IExerciseApiClient
    {
        Task<List<ApiExercise>> GetExercisesForCourseAndSemester(int courseId, int semesterId);
    }
}
