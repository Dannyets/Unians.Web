using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Unians.Exercise.Api.Data.Models;

namespace Unians.Web.Api.GraphQL.Data.Types
{
    public class ExerciseType : ObjectGraphType<ApiExercise>
    {
        public ExerciseType()
        {
            Field(e => e.Id).Description("Id of exercise");
            Field(e => e.Name).Description("Name of exercise");
            Field(e => e.CourseId).Description("Course id exercise is related to");
            Field(e => e.SemesterId).Description("Semester id exercise is related to");
        }
    }
}
