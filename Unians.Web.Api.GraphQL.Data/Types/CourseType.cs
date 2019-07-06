using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Course.Api.Data.Models;
using Unians.Web.Clients.Interfaces;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class CourseType : ObjectGraphType<ApiCourse>
    {
        public CourseType(IExerciseApiClient exerciseApiClient)
        {
            Name = "Course";

            Field(u => u.Id).Description("Id of course");
            Field(u => u.CourseNumber).Description("Course number");
            Field(u => u.Name).Description("Name of course");
            Field(u => u.FacultyId).Description("Id of parent faculty");

            Field<ListGraphType<ExerciseType>>(
                "exercises",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "courseId", Description = "id of course" },
                    new QueryArgument<IdGraphType> { Name = "semesterId", Description = "id of semester" }
                ),
                resolve: context =>
                {
                    var courseId = context.GetArgument<int>("courseId");
                    var semesterId = context.GetArgument<int>("semesterId");

                    return exerciseApiClient.GetExercisesForCourseAndSemester(courseId, semesterId).Result;
                }
            );
        }
    }
}
